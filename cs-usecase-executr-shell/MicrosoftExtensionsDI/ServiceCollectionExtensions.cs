namespace Microsoft.Extensions.DependencyInjection;

using UseCaseExecutR.Registration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddUseCaseExecutR(this IServiceCollection services, 
        Action<UseCaseExecutRServiceConfiguration> configuration)
    {
        var serviceConfig = new UseCaseExecutRServiceConfiguration();

        configuration.Invoke(serviceConfig);

        return services.AddUseCaseExecutR(serviceConfig);
    }
    
    public static IServiceCollection AddUseCaseExecutR(this IServiceCollection services, 
        UseCaseExecutRServiceConfiguration configuration)
    {
        if (!configuration.AssembliesToRegister.Any())
        {
            throw new ArgumentException("No assemblies found to scan. Supply at least one assembly to scan for handlers.");
        }

        ServiceRegistrar.AddUseCaseExecutRClasses(services, configuration);

        ServiceRegistrar.AddRequiredServices(services, configuration);

        return services;
    }
}