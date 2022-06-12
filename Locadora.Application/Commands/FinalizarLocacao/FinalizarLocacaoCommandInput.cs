using MediatR;
using System;

namespace Locadora.Application.Commands.FinalizarLocacao
{
    public class FinalizarLocacaoCommandInput : IRequest<FinalizarLocacaoCommandResult>
    {
        public Guid Id { get; set; }
    }
}
