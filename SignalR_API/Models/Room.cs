using System.Collections.Generic;

namespace SignalR_API.Models
{
    public class Room
    {
        public Room()
        {
            Users = new List<User>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
}
