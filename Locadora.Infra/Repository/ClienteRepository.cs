using Locadora.Domain.ClienteAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Infra.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        List<Cliente> lista = new List<Cliente>() { 
            new Cliente
            (
                Guid.NewGuid(),
                "Joao da Silva",
                new DateTime(1990, 01, 01),
                "031 98070-8080",
                "joao@gmail.com",
                "Rua Alfa, 10, Bairro Industria, Belo Horizonte",
                "100.200.300-30",
                SituacaoCliente.Ativa               
                
            ),

        new Cliente
            (
                Guid.NewGuid(),
                "Jose Santos",
                new DateTime(1985, 05, 06),
                "031 99070-1010",
                "jose@gmail.com",
                "Rua Beta, 20, Bairro Estrela , Belo Horizonte",                
                "300.300.300-30",
                SituacaoCliente.Ativa
            )};

        public ClienteRepository()
        {
        }

        public async Task AddCliente(Cliente cliente)
        {
            lista.Add(cliente);
        }

        public async Task<IEnumerable<Cliente>> GetAllCliente()
        {
            return await Task.FromResult(lista);
        }

        public Cliente GetClienteById(Guid id)
        {
            return lista.FirstOrDefault(x => x.Id == id);
        }

        public Task InativarCliente(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

    }
}
