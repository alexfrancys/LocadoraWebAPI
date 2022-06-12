using MediatR;
using System.Collections.Generic;

namespace Locadora.Application.Queries.GetClientes
{
    public class GetClientesQueryInput : IRequest<IEnumerable<GetClientesQueryResult>>
    {
    }
}
