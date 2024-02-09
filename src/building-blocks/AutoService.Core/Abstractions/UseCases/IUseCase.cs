using AutoService.Core.Web;

namespace AutoService.Core.Abstractions.UseCases
{
    public interface IUseCase<TParameter, TResult>
    {
        Task<RequestResult<TResult>> Execute(TParameter parameter);
    }
}
