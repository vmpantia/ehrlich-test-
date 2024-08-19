using Microsoft.Extensions.DependencyInjection;
using PizzaPlace.Domain.Contractors.Services;
using PizzaPlace.Core.Services;
using System.Reflection;

namespace PizzaPlace.Core.Extensions
{
    public static class ServiceExtension
    {
        public static void AddCore(this IServiceCollection services) =>
            services.AddServices()
                    .AddAutoMapper()
                    .AddMediatR();

        private static IServiceCollection AddServices(this IServiceCollection services) =>
            services.AddScoped(typeof(ISynchronizationService<,>), typeof(SynchronizationService<,>));

        private static IServiceCollection AddAutoMapper(this IServiceCollection services) =>
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

        private static IServiceCollection AddMediatR(this IServiceCollection services) =>
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
    }
}
