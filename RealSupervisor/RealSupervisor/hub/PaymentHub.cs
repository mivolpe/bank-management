using Microsoft.AspNetCore.SignalR;
using RealSupervisor.Interface;
using RealSupervisor.Models;

namespace RealSupervisor.hub
{
    public class PaymentHub : Hub
    {
        private readonly IPaymentService _paymentService;

        public PaymentHub( IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        public async Task GetAllPayments()
        {
            IEnumerable<Payment> test = await _paymentService.GetAllPayments();
            await Clients.All.SendAsync("ServerResponse", test);
        }
    }
}
