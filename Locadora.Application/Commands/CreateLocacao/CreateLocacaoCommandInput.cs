using MediatR;
using System;

namespace Locadora.Application.Commands.CreateLocacao
{
    public class CreateLocacaoCommandInput : IRequest<CreateLocacaoCommandResult>
    {       
        public Guid ClienteId { get; set; }
        public Guid FilmeId { get; set; }
        public int DiasLocacao { get; set; }        
    }
}
