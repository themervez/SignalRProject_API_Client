using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SignalR_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_API.Hubs
{
    public class MyHub : Hub
    {
        private readonly Context _context;

        public MyHub(Context context)
        {
            _context = context;
        }

        public static List<string> Names { get; set; } = new List<string>();
        public static int ClientCount { get; set; } = 0;
        public static int roomCount { get; set; } = 8;//Default roomCount

        public async Task GetNames()
        {
            await Clients.All.SendAsync("ReceiveNames", Names);
        }
        public override async Task OnConnectedAsync()
        {
            ClientCount++;
            await Clients.All.SendAsync("ReceiveClientCount", ClientCount);
        }
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            ClientCount--;
            await Clients.All.SendAsync("ReceiveClientCount", ClientCount);
        }
        public async Task SendName(string name)
        {
            if (Names.Count >= roomCount)
            {
                await Clients.Caller.SendAsync("Error", $"Bu oda en fazla {roomCount} kişi kadar üye alabilir");
            }
            else
            {
                Names.Add(name);
                await Clients.All.SendAsync("ReceiveName", name);
            }
        }
        public async Task SendNameByGroup(string name, string roomName)
        {
            var room = _context.Rooms.Where(x => x.Name == roomName).FirstOrDefault();

            if (room != null)//Eğer zaten kullanıcının bulunduğu bir oda varsa
            {
                room.Users.Add(new User
                {
                    Name = name
                });
            }
            else
            {
                var newRoom = new Room //Yeni kullanıcı için yeni bir oda oluşturuldu
                {
                    Name = roomName
                };

                newRoom.Users.Add(new User { Name = name });
                _context.Rooms.Add(newRoom);
            }

            await _context.SaveChangesAsync();
            await Clients.Group(roomName).SendAsync("ReceiveMessageByGroup", name, room.ID);
        }
        public async Task GetNamesByGroup()
        {
            var rooms = _context.Rooms.Include(x => x.Users).Select(y => new
            {
                roomId = y.ID,
                Users = y.Users.ToList()
            });

            await Clients.All.SendAsync("ReceiveNamesByGroup", rooms);
        }
        public async Task AddToGroup(string roomName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
        }
        public async Task RemoveFromGroup(string roomName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
        }
    }
}