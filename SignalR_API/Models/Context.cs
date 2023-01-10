using Microsoft.EntityFrameworkCore;

namespace SignalR_API.Models
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options):base(options) 
        {
        }
        public DbSet<Room> Rooms { get; }
        public DbSet<User> Users { get; }
    }
}
