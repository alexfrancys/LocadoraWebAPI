using Locadora.Domain.ClienteAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Locadora.Application.Queries.GetClientes
{
    public class GetClientesQueryHandler : IRequestHandler<GetClientesQueryInput, IEnumerable<GetClientesQueryResult>>
    {
        private readonly IClienteRepository _clienteRepository;

        public GetClientesQueryHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
        }

        public async Task<IEnumerable<GetClientesQueryResult>> Handle(GetClientesQueryInput request, CancellationToken cancellationToken)
        {
            return _clienteRepository.GetAllCliente().Result
                .Select(x =>
               new GetClientesQueryResult
               {
                   Id = x.Id,
                   Nome = x.Nome,
                   DataNascimento = x.DataNascimento,
                   Documento = x.Documento,
                   Email = x.Email,
                   Endereco = x.Endereco,
                   Telefone = x.Telefone,
                   Situacao = x.Situacao
               }).OrderBy(x => x.Nome);
        }
    }
}
