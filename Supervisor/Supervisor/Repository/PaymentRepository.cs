using Bank.Context;
using Bank.Interfaces;
using Microsoft.EntityFrameworkCore;
using Supervisor.Models;

namespace Bank.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly BankContext _context;


        public PaymentRepository(BankContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Payment>> GetAllPayments()
        {
            return await _context.Payments.OrderByDescending(d => d.DateTime).ToListAsync();
        }

        public async Task<Payment> GetPaymentById(int id)
        {
            return await _context.Payments.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Payment> CreatePayment(Payment payment)
        {
            await _context.Payments.AddAsync(payment);
            
            await _context.SaveChangesAsync();

            return payment;
        }


    }
}
