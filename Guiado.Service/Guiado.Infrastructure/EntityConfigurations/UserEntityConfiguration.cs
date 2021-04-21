using Guiado.Domain.UserAgregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Guiado.Infrastructure.EntityConfigurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(o => o.ID);
            builder.Property(o => o.Name).IsRequired();
            builder.Property(o => o.Password).IsRequired();
            builder.Property(o => o.Email).IsRequired();
            builder.Property(o => o.Phone).IsRequired();
            builder.Property(o => o.UserType).IsRequired();
        }
    }
}
