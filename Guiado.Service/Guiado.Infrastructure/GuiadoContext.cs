using Guiado.Domain.BusinessAgregate;
using Guiado.Domain.SeedWork;
using Guiado.Domain.UserAgregate;
using Guiado.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

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

    public class GuiadoContextDesignFactory : IDesignTimeDbContextFactory<GuiadoContext>
    {
        private IConfiguration _configuration => new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                                           .AddJsonFile("appsettings.json")
                                                                           .Build();

        public GuiadoContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<GuiadoContext>()
                .UseSqlServer("Server=.\\;Database=Guiado;User ID=guiado.admin;Password=RiU7b3HeV4z&ap;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=false;");

            return new GuiadoContext(optionsBuilder.Options);
        }
    }
}
