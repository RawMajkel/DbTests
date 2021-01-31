using DbTests.Services.Model;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace DbTests.Services
{
    public class DbTestsContext : DbContext
    {
        public DbTestsContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.AppSettings["ConnectionString"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId }).HasName("PK_Order_Details");
                entity.ToTable("Order Details");
                entity.HasIndex(e => e.OrderId).HasDatabaseName("OrdersOrder_Details");
                entity.HasIndex(e => e.ProductId).HasDatabaseName("ProductsOrder_Details");
                entity.Property(e => e.OrderId).HasColumnName("OrderID");
                entity.Property(e => e.ProductId).HasColumnName("ProductID");
                entity.Property(e => e.Quantity).HasDefaultValueSql("((1))");
                entity.Property(e => e.UnitPrice).HasColumnType("money");
            });
        }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
    }
}
