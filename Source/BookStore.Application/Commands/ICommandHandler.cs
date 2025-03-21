using BookStore.Core.Results;
using MediatR;

namespace BookStore.Application.Commands
{
    interface ICommandHandler<TCommand> : IRequestHandler<ICommand, Result>
        where TCommand : ICommand
    {
    }

    interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
        where TCommand : ICommand<TResponse>
    {
    }
}
