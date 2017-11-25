using System.Data.Entity;
using ZooApp.Models;

namespace ZooApp.DAL
{
    public class ZooContext : DbContext
    {
        public ZooContext() : base("ZooContext")
        {

        }

        public DbSet<Animal> Animals { get; set; }
    }
}
