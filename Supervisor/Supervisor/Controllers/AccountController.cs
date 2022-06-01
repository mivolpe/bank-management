using Bank.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Bank.Controllers
{
    [Authorize(Roles = "Manager")]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("accounts")]
        public async Task<IActionResult> GetAllAccount()
        {
            try
            {
                var accounts = await Task.Run(() => _accountService.GetAllAccount());
                return Ok(accounts);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("accounts/{id}")]
        public async Task<IActionResult> GetAccountById(int id)
        {
            try
            {
                var account = await Task.Run(() => _accountService.GetAccountById(id));
                if (account is null) return NotFound("Account not found");
                return Ok(account);
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
