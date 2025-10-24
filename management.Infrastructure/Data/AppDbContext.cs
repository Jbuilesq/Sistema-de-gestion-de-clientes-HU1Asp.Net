using management.Domain.Entitys;
using Microsoft.EntityFrameworkCore;

namespace management.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public AppDbContext(DbContextOptions options) : base(options){}
}