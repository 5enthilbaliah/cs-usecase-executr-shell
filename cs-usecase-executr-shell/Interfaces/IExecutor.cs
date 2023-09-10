// ReSharper disable IdentifierTypo
namespace UseCaseExecutR.Interfaces;

public interface IExecutor
{
    Task ExecuteAsync<TResponse>(IUseCase<TResponse> useCase, CancellationToken cancellationToken = default);
}