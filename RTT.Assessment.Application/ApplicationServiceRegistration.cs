using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace RTT.Assessment.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServiceRegistration(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg => { }, Assembly.GetExecutingAssembly());

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationServiceRegistration).Assembly));
        return services;
    }
}
