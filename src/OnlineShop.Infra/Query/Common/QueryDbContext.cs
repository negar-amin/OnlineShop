using Microsoft.EntityFrameworkCore;
using OnlineShop.Infra.Command.Common;
using OnlineShop.Infra.Query.Entities;

namespace OnlineShop.Infra.Query.Common;

internal class QueryDbContext : DbContext
{
    public QueryDbContext(DbContextOptions<CommandDbContext> options)
: base(options)
    {
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<LineItem> LineItems { get; set; }

}
