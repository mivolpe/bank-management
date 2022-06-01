using RealSupervisor.Models;

namespace RealSupervisor.Interface
{
    public interface IPaymentService
    {
        public Task<IEnumerable<Payment>> GetAllPayments();
        public Task<Payment> GetPaymentById(int id);
        public Task<Payment> CreatePayment(Payment payment);
    }
}
