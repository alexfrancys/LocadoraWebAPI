using MediatR;
using System;

namespace Locadora.Application.Queries.GetClientesById
{
    public class GetClienteByIdQueryInput : IRequest<GetClienteByIdQueryResult>
    {
        public Guid Id { get; set; }
    }
}
