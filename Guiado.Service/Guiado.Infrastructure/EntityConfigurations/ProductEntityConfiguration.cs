using Guiado.Domain.BusinessAgregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Guiado.Infrastructure.EntityConfigurations
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(o => o.ID);
            builder.Property(o => o.Name).IsRequired();
            builder.Property(o => o.Description).IsRequired();
            builder.Property(o => o.Price);
            builder.Property(o => o.ProductFamilyID).IsRequired();
            builder.Property(o => o.Quantity);
            builder.Property(o => o.BusinessID).IsRequired();

            builder.HasOne<Business>().WithMany().HasForeignKey(nameof(Product.BusinessID));
            builder.HasOne<ProductFamily>().WithMany().HasForeignKey(nameof(Product.ProductFamilyID));
        }
    }
}
