using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Model;


namespace DAL
{
    public class WebShopContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderPosition> OrderPositions { get; set; }
        public DbSet<BasketPosition> BasketPositions { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LabTaiib;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasMany(x => x.BasketPositions).WithOne(x => x.Product).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Product>().HasMany(x => x.OrderPositions).WithOne(x => x.Product).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Order>().HasMany(x => x.Positions).WithOne(x => x.Order).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Order>().HasOne(x => x.User).WithMany(x => x.Orders).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>().HasMany(x => x.BasketPositions).WithOne(x => x.User).OnDelete(DeleteBehavior.Cascade);
        }
    }
}