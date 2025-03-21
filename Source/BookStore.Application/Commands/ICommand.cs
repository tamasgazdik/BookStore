using BookStore.Core.Results;
using MediatR;

namespace BookStore.Application.Commands
{
    interface ICommand : IRequest<Result>
    {
    }

    interface ICommand<TResponse> : IRequest<Result<TResponse>>
    {

    }
}
