using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.CommandEntities;
using OnlineShop.Domain.CommandEntities;
using OnlineShop.Domain.CommandEntities;
using OnlineShop.Domain.Common;
using OnlineShop.Infra.Command.Common.Outbox;
using OnlineShop.Infra.Command.Configs;
using System.Net.Http.Headers;
using System.Text.Json;
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
    public DbSet<OutboxMessage> OutboxMessages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductConfigs());
        modelBuilder.ApplyConfiguration(new OrderConfigs());
        modelBuilder.ApplyConfiguration(new CustomerConfigs());
        modelBuilder.ApplyConfiguration(new LineItemConfigs());
        modelBuilder.ApplyConfiguration(new OutboxMessageConfigs());
    }
    public override async Task<int> SaveChangesAsync(
    CancellationToken cancellationToken = default)
    {
        var domainEvents = ChangeTracker
            .Entries<Entity>()
            .SelectMany(x => x.Entity.DomainEvents)
            .ToList();

        foreach (var domainEvent in domainEvents)
        {
            OutboxMessages.Add(new OutboxMessage
            {
                Id = Guid.NewGuid(),
                Type = domainEvent.GetType().FullName!,
                Payload = JsonSerializer.Serialize(domainEvent),
                OccurredOn = domainEvent.OccurredOn
            });
        }

        var result = await base.SaveChangesAsync(cancellationToken);

        foreach (var entity in ChangeTracker.Entries<Entity>())
        {
            entity.Entity.ClearDomainEvents();
        }

        return result;
    }
}