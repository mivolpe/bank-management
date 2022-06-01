using Bank.Interfaces;
using Supervisor.Models;

namespace Bank.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IAccountService _accountService;

        public PaymentService(IPaymentRepository paymentRepository, IAccountService accountService)
        {
            _paymentRepository = paymentRepository;
            _accountService = accountService;
        }

        public async Task<IEnumerable<Payment>> GetAllPayments() => await _paymentRepository.GetAllPayments();

        public async Task<Payment> GetPaymentById(int id) => await _paymentRepository.GetPaymentById(id);

        public async Task<Payment> CreatePayment(Payment payment)
        {
            await _accountService.UpdateAccount(payment.TransmitterId, payment.Amount, "lose");
            await _accountService.UpdateAccount(payment.ReceiverId, payment.Amount, "gain");

            return await _paymentRepository.CreatePayment(payment);
        }

   
    }
}
