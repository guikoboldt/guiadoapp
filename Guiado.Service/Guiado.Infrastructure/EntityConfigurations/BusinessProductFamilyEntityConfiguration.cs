using Guiado.Domain.BusinessAgregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Guiado.Infrastructure.EntityConfigurations
{
    public class BusinessProductFamilyEntityConfiguration : IEntityTypeConfiguration<BusinessProductFamily>
    {
        public void Configure(EntityTypeBuilder<BusinessProductFamily> builder)
        {
            builder.HasKey(o => o.ID);
            builder.Property(o => o.BusinessID).IsRequired();
            builder.Property(o => o.ProductFamilyID).IsRequired();

            builder.HasOne<Business>().WithMany().HasForeignKey(nameof(BusinessProductFamily.BusinessID));
            builder.HasOne<ProductFamily>().WithMany().HasForeignKey(nameof(BusinessProductFamily.ProductFamilyID));
        }
    }
}
