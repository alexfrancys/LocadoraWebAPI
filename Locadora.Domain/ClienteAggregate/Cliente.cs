using System;

namespace Locadora.Domain.ClienteAggregate
{
    public class Cliente
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
        public string Endereco { get; private set; }
        public string Documento { get; private set; }
        public SituacaoCliente Situacao { get; private set; }

        public Cliente(Guid id, string nome, DateTime dataNascimento, string telefone, string email, string endereco, string documento, SituacaoCliente situacao)
        {
            Id = id;
            Nome = nome;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            Email = email;
            Endereco = endereco;
            Documento = documento;
            Situacao = situacao;
        }

        public void InativarCliente()
        {
            Situacao = SituacaoCliente.Desativada;
        }
    }
}
