﻿using BookStore.Core.Results;
using MediatR;

namespace BookStore.Application.Queries
{
    public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
        where TQuery : IQuery<TResponse>
    {
    }
}
