using Locadora.Domain.FilmeAggregate;
using Locadora.Domain.LocacaoAggregate;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Locadora.Application.Commands.FinalizarLocacao
{
    public class FinalizarLocacaoCommandHandler : IRequestHandler<FinalizarLocacaoCommandInput, FinalizarLocacaoCommandResult>
    {
        private readonly ILocacaoRepository _locacaoRepository;
        private readonly IFilmeRepository _filmeRepository;
        public FinalizarLocacaoCommandHandler(ILocacaoRepository locacaoRepository, IFilmeRepository filmeRepository)
        {
            _locacaoRepository = locacaoRepository ?? throw new ArgumentNullException(nameof(locacaoRepository));
            _filmeRepository = filmeRepository ?? throw new ArgumentNullException(nameof(filmeRepository));
        }

        public async Task<FinalizarLocacaoCommandResult> Handle(FinalizarLocacaoCommandInput request, CancellationToken cancellationToken)
        {
            var locacao = _locacaoRepository.GetLocacaoById(request.Id);

            var filme = _filmeRepository.GetFilmeById(locacao.FilmeId);

            locacao.FinalizarLocacao();
            filme.Disponivel();          

            if (locacao.DiasEmAtraso() > 0)
            {
                locacao.AtualizarValorTotal(locacao.ValorTotal + (filme.ValorDiario * locacao.DiasEmAtraso()));
                return new FinalizarLocacaoCommandResult() { ValorTotal = locacao.ValorTotal, DiasAtraso = locacao.DiasEmAtraso() };
            }

            return new FinalizarLocacaoCommandResult() { ValorTotal = locacao.ValorTotal, DiasAtraso = 0 };
        }
    }
}
