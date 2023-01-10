using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalR_API.Hubs;
using System.Threading.Tasks;

namespace SignalR_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IHubContext<MyHub> _hubContext;

        public NotificationController(IHubContext<MyHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpGet("{roomCount}")]
        public async Task<IActionResult> SetRoomCount(int roomCount)
        {
            MyHub.roomCount = roomCount;
            await _hubContext.Clients.All.SendAsync("Notify", $"Bu odada en fazla {roomCount} kişi olabilir.");
            return Ok();
        }
    }
}
