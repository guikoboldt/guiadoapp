using Guiado.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace Guiado.API.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddGuiadoDBContext(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddEntityFrameworkSqlServer()
                           .AddDbContext<GuiadoContext>(options =>
                           {
                               options.UseSqlServer(configuration.GetValue<string>("ConnectionStrings"),
                                   sqlServerOptionsAction: sqlOptions =>
                                   {
                                       sqlOptions.MigrationsAssembly(typeof(GuiadoContext).GetTypeInfo().Assembly.GetName().Name);
                                       sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                                   });
                           });
        }
    }
}
