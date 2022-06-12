using MediatR;
using System;

namespace Locadora.Application.Commands.InativarCliente
{
    public class InativaClienteCommandInput : IRequest<InativarClienteCommandResult>
    {
        public Guid Id { get; set; }
    }
}
