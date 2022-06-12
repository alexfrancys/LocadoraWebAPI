using Locadora.Domain.FilmeAggregate;
using MediatR;
using System;

namespace Locadora.Application.Commands.CreateFilme
{
    public class CreateFilmeCommandInput : IRequest<CreateFilmeCommandResult>
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public decimal ValorDiario { get; set; }
        public SituacaoFilme Situacao { get; set; }

    }    
}
