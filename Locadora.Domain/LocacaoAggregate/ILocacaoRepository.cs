using System;
using System.Threading.Tasks;

namespace Locadora.Domain.LocacaoAggregate
{
    public interface ILocacaoRepository
    {
        Task NewLocacao(Locacao locacao);
        Locacao GetLocacaoById(Guid Id);
    }
}
