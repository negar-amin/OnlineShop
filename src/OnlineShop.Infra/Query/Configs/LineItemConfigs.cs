using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Infra.Query.Entities;

namespace OnlineShop.Infra.Query.Configs;

internal class LineItemConfigs : IEntityTypeConfiguration<LineItem>
{
    public void Configure(EntityTypeBuilder<LineItem> builder)
    {
        builder.ToTable(nameof(LineItem));
        builder.HasNoKey();
    }
}
