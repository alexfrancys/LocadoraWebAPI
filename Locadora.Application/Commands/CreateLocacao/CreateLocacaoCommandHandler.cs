using Locadora.Domain.FilmeAggregate;
using Locadora.Domain.LocacaoAggregate;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Locadora.Application.Commands.CreateLocacao
{
    public class CreateLocacaoCommandHandler : IRequestHandler<CreateLocacaoCommandInput, CreateLocacaoCommandResult>
    {
        private readonly ILocacaoRepository _locacaoRepository;
        private readonly IFilmeRepository _filmeRepository;

        public CreateLocacaoCommandHandler(ILocacaoRepository locacaoRepository, IFilmeRepository filmeRepository)
        {
            _locacaoRepository = locacaoRepository ?? throw new ArgumentNullException(nameof(locacaoRepository));
            _filmeRepository = filmeRepository ?? throw new ArgumentNullException(nameof(filmeRepository));
        }

        public async Task<CreateLocacaoCommandResult> Handle(CreateLocacaoCommandInput request, CancellationToken cancellationToken)
        {
            var dataDevolucaoPrevista = DateTime.Now;
            //dataDevolucaoPrevista = dataDevolucaoPrevista.AddDays(request.DiasLocacao);
            dataDevolucaoPrevista = new DateTime(2022, 06, 10);

            var filme = _filmeRepository.GetFilmeById(request.FilmeId);

            if (filme.Situacao == SituacaoFilme.Locado)
                throw new Exception("O filme selecionado está locado.");

            filme.Locado();

            var locacao = new Locacao(
                Guid.NewGuid(),
                request.ClienteId,
                request.FilmeId,
                DateTime.Now,
                dataDevolucaoPrevista,
                DateTime.MinValue,
                (filme.ValorDiario * request.DiasLocacao),
                LocacaoSituacao.EmAndamento
            );

            await _locacaoRepository.NewLocacao(locacao);

            return new CreateLocacaoCommandResult() { Id = locacao.Id };
        }
    }
}
