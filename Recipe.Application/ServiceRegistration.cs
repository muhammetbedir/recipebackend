using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Recipe.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
