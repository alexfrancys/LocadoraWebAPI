using MediatR;
using System.Collections.Generic;

namespace Locadora.Application.Queries.GetFilmes
{
    public class GetFilmesQueryInput : IRequest<IEnumerable<GetFilmesQueryResult>>
    {
    }
}
