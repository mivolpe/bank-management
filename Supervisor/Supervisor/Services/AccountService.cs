using Bank.Interfaces;
using Supervisor.Models;

namespace Bank.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<Account> GetAccountById(int id) => await _accountRepository.GetAccountById(id);

        public Task<List<Account>> GetAllAccount() => _accountRepository.GetAllAccount();

        public async Task<Account> UpdateAccount(int id, decimal amount, string type)
        {
            var account = await GetAccountById(id);

            if (type.Equals("lose"))
            {
                account.Amount -= amount;
            }
            else
            {
                account.Amount += amount;
            }

            return await _accountRepository.UpdateAccount(account);
        }
    }
}
