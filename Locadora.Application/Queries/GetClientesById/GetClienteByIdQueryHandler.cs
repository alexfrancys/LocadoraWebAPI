using Locadora.Domain.ClienteAggregate;
using Locadora.Infra.Repository;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Locadora.Application.Queries.GetClientesById
{
    public class GetClienteByIdQueryHandler : IRequestHandler<GetClienteByIdQueryInput, GetClienteByIdQueryResult>
    {
        private readonly IClienteRepository _clienteRepository;

        public GetClienteByIdQueryHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
        }

        public async Task<GetClienteByIdQueryResult> Handle(GetClienteByIdQueryInput request, CancellationToken cancellationToken)
        {            
            var result = _clienteRepository.GetClienteById(request.Id);

            return new GetClienteByIdQueryResult
            {
                Id = result.Id,
                Nome = result.Nome,
                DataNascimento = result.DataNascimento,
                Documento = result.Documento,
                Email = result.Email,
                Endereco = result.Endereco,
                Telefone = result.Telefone
            };
        }
    }
}
