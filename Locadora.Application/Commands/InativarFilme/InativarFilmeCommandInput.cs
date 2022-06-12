using MediatR;
using System;

namespace Locadora.Application.Commands.InativarFilme
{
    public class InativarFilmeCommandInput : IRequest<InativarFilmeCommandResult>
    {
        public Guid Id { get; set; }
    }
}
