using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealSupervisor.Interface;
using RealSupervisor.Models;

namespace RealSupervisor.Controller
{
    [Route("api/")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IClientLogin _clientLogin;

        public LoginController(IClientLogin clientLogin)
        {
            _clientLogin = clientLogin;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginToBank([FromBody] ClientLogin clientLogin)
        {
            var role = await _clientLogin.LogClient(clientLogin);
            if (role.ToString() == "Manager")
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
