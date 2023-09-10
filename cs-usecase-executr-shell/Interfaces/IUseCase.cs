// ReSharper disable IdentifierTypo
namespace UseCaseExecutR.Interfaces;

public interface IUseCase<TViewModel> : IBaseUseCase
{
    TViewModel Vm { get; set; }
}

public interface IBaseUseCase { }