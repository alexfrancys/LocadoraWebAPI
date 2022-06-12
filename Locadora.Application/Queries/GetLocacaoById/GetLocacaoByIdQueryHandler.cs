using Locadora.Domain.LocacaoAggregate;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Locadora.Application.Queries.GetLocacaoById
{
    public class GetLocacaoByIdQueryHandler : IRequestHandler<GetLocacaoByIdQueryInput, GetLocacaoByIdQueryResult>
    {
        private readonly ILocacaoRepository _locacaoRepository;

        public GetLocacaoByIdQueryHandler(ILocacaoRepository locacaoRepository)
        {
            _locacaoRepository = locacaoRepository ?? throw new ArgumentNullException(nameof(locacaoRepository));
        }

        public async Task<GetLocacaoByIdQueryResult> Handle(GetLocacaoByIdQueryInput request, CancellationToken cancellationToken)
        {
            var locacao = _locacaoRepository.GetLocacaoById(request.Id);

            return new GetLocacaoByIdQueryResult()
            {
                Id = locacao.Id,
                ClienteId = locacao.ClienteId,
                FilmeId = locacao.FilmeId,
                DataInicio = locacao.DataInicio,
                DataDevolucaoPrevista = locacao.DataDevolucaoPrevista,
                DataDevolucaoReal = locacao.DataDevolucaoReal,
                ValorTotal = locacao.ValorTotal
            };
        }
    }
}
