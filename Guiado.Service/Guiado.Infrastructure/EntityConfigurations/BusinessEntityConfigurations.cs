﻿using Guiado.Domain.BusinessAgregate;
using Guiado.Domain.UserAgregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Guiado.Infrastructure.EntityConfigurations
{
    public class BusinessEntityConfigurations : IEntityTypeConfiguration<Business>
    {
        public void Configure(EntityTypeBuilder<Business> builder)
        {
            builder.HasKey(o => o.Id);
            builder.HasOne<User>().WithMany().HasForeignKey(nameof(Business.Owner)).IsRequired();
            builder.Property(o => o.CoverArea).IsRequired();
            builder.Property(o => o.StartBusinessHour).IsRequired();
            builder.Property(o => o.EndBusinessHour).IsRequired();
            builder.Property(o => o.AvailableDays).IsRequired();
            builder.Property(o => o.Phone).IsRequired();
            builder.Property(o => o.Email).IsRequired();

            var navigation = builder.Metadata.FindNavigation(nameof(Business.ProductFamilies));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            navigation = builder.Metadata.FindNavigation(nameof(Business.Products));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
