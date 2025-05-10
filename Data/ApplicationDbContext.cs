using Microsoft.EntityFrameworkCore;
using RestaurantApplication.Models;

namespace RestaurantApplication.Data {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Staff> Staffs { get; set; }
    }
}
