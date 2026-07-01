using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.CommandEntities;

namespace OnlineShop.Infra.Command.Configs;

internal class OrderConfigs : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable(nameof(Order));
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.LineItems)
            .WithOne()
            .HasForeignKey(x => x.OrderId);
    }
}
