using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.CommandEntities;
using OnlineShop.Domain.ValueObjects;

namespace OnlineShop.Infra.Command.Configs;

internal class CustomerConfigs : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable(nameof(Customer));
        builder.HasKey(x => x.Id);
        builder.OwnsOne(x => x.PhoneNumber, phone =>
        {
            phone.Property(p => p.Value)
                .HasColumnName(nameof(PhoneNumber))
                .HasMaxLength(11)
                .IsRequired();
        });
    }
}
