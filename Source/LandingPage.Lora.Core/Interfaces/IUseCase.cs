namespace LandingPage.Lora.Core.Interfaces;

public interface IUseCase<TData, TInput>
{
    Task<TData> Execute(TInput input);
}

public interface IUseCase<TData>
{
    Task<TData> Execute();
}

public interface IUseCase
{
    Task Execute();
}