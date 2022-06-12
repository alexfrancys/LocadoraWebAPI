using Locadora.Domain.FilmeAggregate;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Locadora.Application.Queries.GetFilmeById
{
    public class GetFilmeByIdQueryHandler : IRequestHandler<GetFilmesByIdQueryInput, GetFilmesByIdQueryResult>
    {
        private readonly IFilmeRepository _filmeRepository;

        public GetFilmeByIdQueryHandler(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository ?? throw new ArgumentNullException(nameof(filmeRepository));
        }

        public async Task<GetFilmesByIdQueryResult> Handle(GetFilmesByIdQueryInput request, CancellationToken cancellationToken)
        {
            var filme = _filmeRepository.GetFilmeById(request.Id);

            return new GetFilmesByIdQueryResult
            {
                Id = filme.Id,
                Titulo = filme.Titulo,
                Genero = filme.Genero,
                Situacao = filme.Situacao,
                ValorDiario = filme.ValorDiario
            };
        }
    }
}
