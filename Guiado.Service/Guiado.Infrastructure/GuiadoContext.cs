using Guiado.Domain.BusinessAgregate;
using Guiado.Domain.SeedWork;
using Guiado.Domain.UserAgregate;
using Guiado.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Guiado.Infrastructure
{
    public class GuiadoContext : DbContext, IUnitOfWork
    {
        public DbSet<Business> Businesses { get; set; }
        public DbSet<BusinessProductFamily> BusinessProductFamily { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFamily> ProductFamilies { get; set; }
        public DbSet<User> Users { get; set; }

        public GuiadoContext(DbContextOptions<GuiadoContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new BusinessEntityConfigurations());
            modelBuilder.ApplyConfiguration(new BusinessProductFamilyEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProductFamilyEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        }


    }
}
