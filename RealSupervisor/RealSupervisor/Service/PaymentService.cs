using RealSupervisor.Interface;
using RealSupervisor.Models;

namespace RealSupervisor.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly HttpClient _httpClient;

        public PaymentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Payment?> CreatePayment(Payment payment)
        {
            var response = await _httpClient.PostAsJsonAsync("Payment/makePayment", payment);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Payment>();
        }

        public async Task<IEnumerable<Payment>?> GetAllPayments()
        {
            var response = await _httpClient.GetAsync("Payment/payments");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<Payment>>();
        }

        public async Task<Payment?> GetPaymentById(int id)
        {
            var response = await _httpClient.GetAsync($"Payment/payments/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Payment>();
        }
    }
}
