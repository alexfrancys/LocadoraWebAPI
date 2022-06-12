using Locadora.Domain.FilmeAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Infra.Repository
{
    public class FilmeRepository : IFilmeRepository
    {
        List<Filme> lista = new List<Filme>(){
            new Filme( Guid.NewGuid(), "Titanic", "Drama", 10,  SituacaoFilme.Disponivel ),
            new Filme( Guid.NewGuid(), "Minions", "Animacao", 8, SituacaoFilme.Disponivel )
        };

        public FilmeRepository()
        {
        }

        public async Task AddFilme(Filme filme)
        {
            lista.Add(filme);
        }

        public async Task UpdateFilme(Filme filme)
        {

        }

        public Filme GetFilmeById(Guid id)
        {
            return lista.FirstOrDefault(x => x.Id == id);
        }

        public async Task<IEnumerable<Filme>> GetFilmes()
        {
            return await Task.FromResult(lista);
        }

    }
}
