using Bank.Context;
using Bank.Interfaces;
using Microsoft.EntityFrameworkCore;
using Supervisor.Models;

namespace Bank.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BankContext _context;


        public AccountRepository(BankContext context)
        {
            _context = context;
        }
        public async Task<Account> GetAccountById(int id)
        {
            return await _context.Accounts.FirstOrDefaultAsync(a => a.Id == id);

        }

        public async Task<List<Account>> GetAllAccount()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<Account> UpdateAccount(Account account)
        {
            var oldAccount = await GetAccountById(account.Id);
            if (oldAccount == null) return null;

            oldAccount.Amount = account.Amount;

            await _context.SaveChangesAsync();


            return account;
        }
    }
}
