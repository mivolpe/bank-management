using RealSupervisor.Interface;
using RealSupervisor.Models;

namespace RealSupervisor.Service
{
    public class ClientLoginService : IClientLogin
    {
        private readonly HttpClient _httpClient;

        public ClientLoginService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> LogClient(ClientLogin clientLogin)
        {
            var response = await _httpClient.PostAsJsonAsync("login", new { email = clientLogin.Email, password = clientLogin.Password });
            response.EnsureSuccessStatusCode();
            var clientRep =  await response.Content.ReadFromJsonAsync<Client>();
            return clientRep.Role;
        }
    }
}
