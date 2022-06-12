using Locadora.Domain.ClienteAggregate;
using MediatR;
using System;

namespace Locadora.Application.Commands.CreateCliente
{
    public class CreateClienteCommandInput : IRequest<CreateClienteCommandResult>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Documento { get; set; }
        public SituacaoCliente Situacao { get; set; }
    }
}
