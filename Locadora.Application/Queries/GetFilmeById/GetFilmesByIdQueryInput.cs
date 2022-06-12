using MediatR;
using System;

namespace Locadora.Application.Queries.GetFilmeById
{
    public class GetFilmesByIdQueryInput : IRequest<GetFilmesByIdQueryResult>
    {
        public Guid Id { get; set; }
    }
}
