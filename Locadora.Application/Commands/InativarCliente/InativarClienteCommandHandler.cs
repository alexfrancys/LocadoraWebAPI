using Locadora.Domain.ClienteAggregate;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Locadora.Application.Commands.InativarCliente
{
    public class InativarClienteCommandHandler : IRequestHandler<InativaClienteCommandInput, InativarClienteCommandResult>
    {
        private readonly IClienteRepository _clienteRepository;

        public InativarClienteCommandHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
        }

        public async Task<InativarClienteCommandResult> Handle(InativaClienteCommandInput request, CancellationToken cancellationToken)
        {
            var cliente = _clienteRepository.GetClienteById(request.Id);

            cliente.InativarCliente();

            return new InativarClienteCommandResult();
        }
    }
}
