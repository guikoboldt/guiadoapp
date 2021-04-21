using Guiado.Domain.BusinessAgregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Guiado.Infrastructure.EntityConfigurations
{
    public class ProductFamilyEntityConfiguration : IEntityTypeConfiguration<ProductFamily>
    {
        public void Configure(EntityTypeBuilder<ProductFamily> builder)
        {
            builder.HasKey(o => o.ID);
            builder.Property(o => o.Name).IsRequired();
            builder.Property(o => o.Description).IsRequired();
        }
    }
}
