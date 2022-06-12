using System;

namespace Locadora.Application.Queries.GetLocacaoById
{
    public class GetLocacaoByIdQueryResult
    {
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public Guid FilmeId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataDevolucaoPrevista { get; set; }
        public DateTime DataDevolucaoReal { get; set; }
        public Decimal ValorTotal { get; set; }
    }
}
