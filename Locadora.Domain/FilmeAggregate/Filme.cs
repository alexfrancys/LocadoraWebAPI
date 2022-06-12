using System;

namespace Locadora.Domain.FilmeAggregate
{
    public class Filme
    {
        public Guid Id { get; private set; }
        public string Titulo { get; private set; }
        public string Genero { get; private set; }
        public decimal ValorDiario { get; private set; }
        public SituacaoFilme Situacao { get; private set; }

        public Filme(Guid id, string titulo, string genero, decimal valorDiario, SituacaoFilme situacao)
        {
            Id = id;
            Titulo = titulo;
            Genero = genero;
            ValorDiario = valorDiario;
            Situacao = situacao;
        }

        public void Inativarfilme()
        {
            Situacao = SituacaoFilme.Excluido;
        }

        public void Locado()
        {
            Situacao = SituacaoFilme.Locado;
        }

        public void Disponivel()
        {
            Situacao = SituacaoFilme.Disponivel;
        }
    }
}
