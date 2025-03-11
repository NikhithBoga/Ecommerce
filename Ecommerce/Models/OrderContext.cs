using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Models
{
    
    
        public class OrderContext : DbContext
        {
            public OrderContext() { }

            public OrderContext(DbContextOptions options) : base(options)
            {
                Database.EnsureCreated();
            }


            public DbSet<Order> Orders_ { get; set; }
            public DbSet<OrderItem> OrderItems_ { get; set; }


            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Order>()
                    .HasMany(o => o.OrderItems_)
                    .WithOne(oi => oi.Order)
                    .HasForeignKey(oi => oi.OrderId);
            }


        }
    
}
