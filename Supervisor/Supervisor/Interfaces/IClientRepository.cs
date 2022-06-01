using Bank.Models;
using Supervisor.Models;

namespace Bank.Interfaces
{
    public interface IClientRepository
    {
        public Task<Client> Get(ClientLogin ClientLogin);

        public Task<List<Client>> GetAllClient();

        public Task<Client> GetClientById(int id);

    }
}
