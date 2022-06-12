using System;

namespace Locadora.Domain.LocacaoAggregate
{
    public class Locacao
    {
        public Guid Id { get; }
        public Guid ClienteId { get; }
        public Guid FilmeId { get; }
        public DateTime DataInicio { get; }
        public DateTime DataDevolucaoPrevista { get; }
        public DateTime DataDevolucaoReal { get; private set; }
        public Decimal ValorTotal { get; private set; }
        public LocacaoSituacao Situacao { get; private set; }


        public Locacao(Guid id, Guid clienteId, Guid filmeId, DateTime dataInicio, DateTime dataDevolucaoPrevista, DateTime dataDevolucaoReal, decimal valorTotal, LocacaoSituacao situacao)
        {
            Id = id;
            ClienteId = clienteId;
            FilmeId = filmeId;
            DataInicio = dataInicio;
            DataDevolucaoPrevista = dataDevolucaoPrevista;
            DataDevolucaoReal = dataDevolucaoReal;
            ValorTotal = valorTotal;
            Situacao = situacao;
        }

        public int DiasEmAtraso()
        {
            if (DateTime.Now > DataDevolucaoPrevista)
            {
                var diasAtradados = DataDevolucaoReal.Day - DataDevolucaoPrevista.Day;
                return diasAtradados;
            }

            return 0;
        }

        public void AtualizarValorTotal(Decimal valor)
        {
            ValorTotal = valor;
        }

        public void FinalizarLocacao()
        {
            DataDevolucaoReal = DateTime.Now;
            Situacao = LocacaoSituacao.Finalizada;
        }
        
    }
}
