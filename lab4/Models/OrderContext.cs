using Microsoft.EntityFrameworkCore;
namespace lab4.Models
{
    public class OrderContext : DbContext
    {
        public DbSet<Users> Users { get; set; }

        public DbSet<Orders> Orders { get; set; }
        public DbSet<Services> Services { get; set; }
    }
}
