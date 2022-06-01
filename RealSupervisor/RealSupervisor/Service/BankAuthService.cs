using Microsoft.Extensions.Caching.Memory;
using RealSupervisor.Interface;
using RealSupervisor.Models;

namespace RealSupervisor.Service
{
    public class BankAuthService : IBankAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _memoryCache;

        public BankAuthService(HttpClient httpClient, IMemoryCache memoryCache)
        {
            _httpClient = httpClient;
            _memoryCache = memoryCache;
        }

        public async Task<string?> RetrieveToken()
        {
            var inscriptionDateTime = DateTime.UtcNow.AddMinutes(60); // refresh...
            if (!_memoryCache.TryGetValue("Token", out string? token))
            {
                var response = await _httpClient.PostAsJsonAsync("login", new { email = "sam@hotmail.com", password = "123456" });
                response.EnsureSuccessStatusCode();
                var authResponse = await response.Content.ReadFromJsonAsync<AuthResponse>();
                token = authResponse?.Token;
                _memoryCache.Set("Token", token, new DateTimeOffset(inscriptionDateTime));
            }

            return token;
        }

    }
}
