using Microsoft.EntityFrameworkCore;
using PizzaPlace.Domain.Models.Entities;

namespace PizzaPlace.Infrastructure.Databases.Contexts
{
    public class PizzaPlaceDbContext : DbContext
    {
        public PizzaPlaceDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<PizzaType> PizzaTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Setup database table configurations
            modelBuilder.Entity<Order>(o =>
            {
                o.HasMany(o => o.OrderDetails)
                 .WithOne(od => od.Order)
                 .HasForeignKey(od => od.OrderId)
                 .IsRequired();
            });
            modelBuilder.Entity<OrderDetail>(od =>
            {
                od.HasOne(od => od.Order)
                  .WithMany(o => o.OrderDetails)
                  .HasForeignKey(od => od.OrderId)
                  .IsRequired();

                od.HasOne(od => od.Pizza)
                  .WithMany(p => p.OrderDetails)
                  .HasForeignKey(od => od.PizzaId)
                  .IsRequired();
            });
            modelBuilder.Entity<Pizza>(p => 
            {
                p.HasOne(p => p.PizzaType)
                 .WithMany(pt => pt.Pizzas)
                 .HasForeignKey(p => p.PizzaTypeId)
                 .IsRequired();

                p.HasMany(p => p.OrderDetails)
                 .WithOne(od => od.Pizza)
                 .HasForeignKey(od => od.PizzaId)
                 .IsRequired();

                p.Property(p => p.Price)
                 .HasColumnType("decimal(8,2)");
            });
            modelBuilder.Entity<PizzaType>(pt =>
            {
                pt.HasMany(pt => pt.Pizzas)
                  .WithOne(p => p.PizzaType)
                  .HasForeignKey(p => p.PizzaTypeId)
                  .IsRequired();
            });
            #endregion
        }
    }
}
