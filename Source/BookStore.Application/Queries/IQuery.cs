using BookStore.Core.Results;
using MediatR;

namespace BookStore.Application.Queries
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
