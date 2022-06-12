using Locadora.Domain.LocacaoAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Infra.Repository
{
    public class LocacaoRepository : ILocacaoRepository
    {
        List<Locacao> lista = new List<Locacao>();
       
        public async Task NewLocacao(Locacao locacao)
        {  
            lista.Add(locacao);
        }

        public Locacao GetLocacaoById(Guid Id)
        {
            return lista.FirstOrDefault(x => x.Id == Id);
        }

    }
}
