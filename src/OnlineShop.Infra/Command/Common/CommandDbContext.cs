using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using OnlineShop.Domain;
using OnlineShop.Infra.Command.Configs;
namespace OnlineShop.Infra.Command.Common;

public class CommandDbContext : DbContext
{
    public CommandDbContext(DbContextOptions<CommandDbContext> options)
    : base(options)
    {
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<LineItem> LineItems { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductConfigs());
        modelBuilder.ApplyConfiguration(new OrderConfigs());
        modelBuilder.ApplyConfiguration(new CustomerConfigs());
        modelBuilder.ApplyConfiguration(new LineItemConfigs());
    }
}