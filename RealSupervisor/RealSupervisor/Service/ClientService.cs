using RealSupervisor.Interface;
using RealSupervisor.Models;

namespace RealSupervisor.Service
{
    public class ClientService: IClientService 
    {
        private readonly HttpClient _httpClient;

        public ClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Client>> GetAllClient()
        {
            var response = await _httpClient.GetAsync("Client/clients");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<Client>>();
        }
    }
}
