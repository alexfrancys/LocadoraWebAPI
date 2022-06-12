using Locadora.Domain.FilmeAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Locadora.Application.Commands.CreateFilme
{
    public class CreateFilmeCommandHandler : IRequestHandler<CreateFilmeCommandInput, CreateFilmeCommandResult>
    {
        private readonly IFilmeRepository _filmeRepository;

        public CreateFilmeCommandHandler(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository ?? throw new ArgumentNullException(nameof(filmeRepository));
        }

        public async Task<CreateFilmeCommandResult> Handle(CreateFilmeCommandInput request, CancellationToken cancellationToken)
        {
            var filme = new Filme(
                 Guid.NewGuid(),
                 request.Titulo,
                 request.Genero,
                 request.ValorDiario,
                 request.Situacao
            );

            if (filme is not null)
                await _filmeRepository.AddFilme(filme);

            return new CreateFilmeCommandResult() { Id = filme.Id };
        }
    }
}
