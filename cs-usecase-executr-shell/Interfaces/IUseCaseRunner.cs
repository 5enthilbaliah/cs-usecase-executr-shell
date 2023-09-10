// ReSharper disable IdentifierTypo
namespace UseCaseExecutR.Interfaces;

public interface IUseCaseRunner<in TUseCase, TViewModel>
    where TUseCase : IUseCase<TViewModel>
{
    Task<TViewModel> Run(TUseCase useCase, CancellationToken cancellationToken);
}