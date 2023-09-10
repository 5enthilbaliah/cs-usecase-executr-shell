namespace Microsoft.Extensions.DependencyInjection;

using System.Reflection;

using UseCaseExecutR;

public class UseCaseExecutRServiceConfiguration
{
    public Func<Type, bool> TypeEvaluator { get; set; } = t => true;
    public Type MediatorImplementationType { get; set; } = typeof(Executor);
    public ServiceLifetime Lifetime { get; set; } = ServiceLifetime.Transient;

    internal List<Assembly> AssembliesToRegister { get; } = new();
    
    public UseCaseExecutRServiceConfiguration RegisterServicesFromAssembly(Assembly assembly)
    {
        AssembliesToRegister.Add(assembly);

        return this;
    }
}