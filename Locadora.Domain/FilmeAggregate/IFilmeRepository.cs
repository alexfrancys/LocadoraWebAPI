using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.Domain.FilmeAggregate
{
    public interface IFilmeRepository 
    {
        Task AddFilme(Filme filme);
        Task UpdateFilme(Filme filme);
        Task<IEnumerable<Filme>> GetFilmes();
        Filme GetFilmeById(Guid filmeId);
    }
}
