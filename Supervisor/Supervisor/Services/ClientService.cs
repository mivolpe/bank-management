using Bank.Interfaces;
using Bank.Models;
using Supervisor.Models;

namespace Bank.Services
{
    public class ClientService: IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Client> Get(ClientLogin ClientLogin) => await _clientRepository.Get(ClientLogin);

        public async Task<List<Client>> GetAllClient() => await _clientRepository.GetAllClient();

        public async Task<Client> GetClientById(int id) => await _clientRepository.GetClientById(id);
    }
}
