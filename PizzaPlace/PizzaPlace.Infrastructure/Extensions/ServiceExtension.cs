using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PizzaPlace.Infrastructure.Databases.Contexts;

namespace PizzaPlace.Infrastructure.Extensions
{
    public static class ServiceExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDatabases(configuration);

        private static IServiceCollection AddDatabases(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<PizzaPlaceDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("MigrationDb")));
    }
}
