using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RTT.Assessment.Application.Contracts.Persistence;
using RTT.Assessment.Persistence.DatabaseContext;

namespace RTT.Assessment.Persistence;

public static class PersistanceServiceRegistration
{
    public static IServiceCollection AddPersistenceServiceRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        // DB connection string
        var connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        services.AddSingleton<IDbConnectionFactory>(_ => new DbConnectionFactory(connectionString));

        // Repositories
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IPersonRepository, PersonRespository>();
        services.AddScoped<IContactRepository, ContactRepository>();
        services.AddScoped<IAddressRepository, AddressRepository>();    

        return services;
    }
}
