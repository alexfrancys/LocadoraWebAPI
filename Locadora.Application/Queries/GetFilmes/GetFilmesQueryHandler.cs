using Locadora.Domain.FilmeAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Locadora.Application.Queries.GetFilmes.GetLocacaoById
{
    public class GetFilmesQueryHandler : IRequestHandler<GetFilmesQueryInput, IEnumerable<GetFilmesQueryResult>> 
    {
        private readonly IFilmeRepository _filmeRepository;

        public GetFilmesQueryHandler(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository ?? throw new ArgumentNullException(nameof(filmeRepository));
        }

        public async Task<IEnumerable<GetFilmesQueryResult>> Handle(GetFilmesQueryInput request, CancellationToken cancellationToken)
        {
            return _filmeRepository.GetFilmes().Result.Select(
                x => new GetFilmesQueryResult
                {
                    Id = x.Id,
                    Titulo = x.Titulo,
                    Genero = x.Genero,
                    Situacao = x.Situacao,
                    ValorDiario = x.ValorDiario
                }).OrderBy(x => x.Titulo);
        }
    }
}
