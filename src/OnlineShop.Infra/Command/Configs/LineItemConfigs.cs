using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.CommandEntities;

namespace OnlineShop.Infra.Command.Configs;

internal class LineItemConfigs : IEntityTypeConfiguration<LineItem>
{
    public void Configure(EntityTypeBuilder<LineItem> builder)
    {
        builder.ToTable(nameof(LineItem));
        builder.HasKey(x => x.Id);
    }
}
