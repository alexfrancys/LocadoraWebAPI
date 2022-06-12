using Locadora.Domain.FilmeAggregate;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Locadora.Application.Commands.InativarFilme
{
    public class InativarFilmeCommandHandler : IRequestHandler<InativarFilmeCommandInput, InativarFilmeCommandResult>
    {
        private readonly IFilmeRepository _filmeRepository;
        public InativarFilmeCommandHandler(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository ?? throw new ArgumentNullException(nameof(filmeRepository));
        }

        public async Task<InativarFilmeCommandResult> Handle(InativarFilmeCommandInput request, CancellationToken cancellationToken)
        {
            var filme = _filmeRepository.GetFilmeById(request.Id);

            filme.Inativarfilme();

            return new InativarFilmeCommandResult();

        }
    }
}
