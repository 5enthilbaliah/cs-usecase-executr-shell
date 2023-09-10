// ReSharper disable IdentifierTypo
namespace UseCaseExecutR;

using System.Collections.Concurrent;

using Interfaces;

using Wrappers;

public class Executor: IExecutor
{
    private readonly IServiceProvider _serviceProvider;
    private static readonly ConcurrentDictionary<Type, RequestHandlerBase> _requestHandlers = new();
    
    public Executor(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    
    public async Task ExecuteAsync<TViewModel>(IUseCase<TViewModel> useCase, CancellationToken cancellationToken = default)
    {
        if (useCase == null)
        {
            throw new ArgumentNullException(nameof(useCase));
        }

        var handler = (RequestHandlerWrapper<TViewModel>)_requestHandlers.GetOrAdd(useCase.GetType(), static requestType =>
        {
            var wrapperType = typeof(RequestHandlerWrapperImpl<,>).MakeGenericType(requestType, typeof(TViewModel));
            var wrapper = Activator.CreateInstance(wrapperType) ?? throw new InvalidOperationException($"Could not create wrapper type for {requestType}");
            return (RequestHandlerBase)wrapper;
        });

        var result = await handler.Handle(useCase, _serviceProvider, cancellationToken);
        useCase.Vm = result;
    }
}