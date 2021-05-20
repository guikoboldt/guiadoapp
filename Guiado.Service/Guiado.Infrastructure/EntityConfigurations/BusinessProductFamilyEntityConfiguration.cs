﻿using Guiado.Domain.BusinessAgregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Guiado.Infrastructure.EntityConfigurations
{
    public class BusinessProductFamilyEntityConfiguration : IEntityTypeConfiguration<BusinessProductFamily>
    {
        public void Configure(EntityTypeBuilder<BusinessProductFamily> builder)
        {
            builder.HasKey(o => o.Id);
            //builder.HasOne<Business>().WithMany().HasForeignKey(nameof(BusinessProductFamily.BusinessId)).IsRequired();
            builder.HasOne<ProductFamily>().WithMany().HasForeignKey(nameof(BusinessProductFamily.ProductFamilyId)).IsRequired();
        }
    }
}
