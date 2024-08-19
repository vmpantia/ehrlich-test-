using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PizzaPlace.Domain.Contractors.Repositories;
using PizzaPlace.Infrastructure.Databases.Contexts;
using PizzaPlace.Infrastructure.Databases.Repositories;

namespace PizzaPlace.Infrastructure.Extensions
{
    public static class ServiceExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDatabases(configuration);

        private static IServiceCollection AddDatabases(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<PizzaPlaceDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("MigrationDb")));

        private static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration) =>
            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
    }
}
