using Locadora.Domain.ClienteAggregate;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Locadora.Application.Commands.CreateCliente
{
    public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommandInput, CreateClienteCommandResult>
    {
        private readonly IClienteRepository _clienteRepository;
        public CreateClienteCommandHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
        }

        public async Task<CreateClienteCommandResult> Handle(CreateClienteCommandInput request, CancellationToken cancellationToken)
        {
            var cliente = new Cliente(
            
                Guid.NewGuid(),
                request.Nome,
                request.DataNascimento,
                request.Telefone,
                request.Email,
                request.Endereco,
                request.Documento,                            
                request.Situacao               
            );

            if(cliente is not null)
            await _clienteRepository.AddCliente(cliente);

            return new CreateClienteCommandResult() { Id = cliente.Id };
        }
    }
}
