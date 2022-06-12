using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.Domain.ClienteAggregate
{
    public interface IClienteRepository
    {
        Task AddCliente(Cliente cliente);
        Task UpdateCliente(Cliente cliente);
        Task<IEnumerable<Cliente>> GetAllCliente();
        Cliente GetClienteById(Guid id);
        Task InativarCliente(Guid id);      
    }
}
