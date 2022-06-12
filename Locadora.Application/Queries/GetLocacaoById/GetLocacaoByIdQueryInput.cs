using MediatR;
using System;

namespace Locadora.Application.Queries.GetLocacaoById
{
    public class GetLocacaoByIdQueryInput : IRequest<GetLocacaoByIdQueryResult>
    {
        public Guid Id { get; set; }
    }
}
