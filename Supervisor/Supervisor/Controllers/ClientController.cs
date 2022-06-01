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
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController( IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet("clients")]
        public async Task<IActionResult> GetAllClient()
        {
            try
            {
                var clients = await Task.Run(() => _clientService.GetAllClient());
                return Ok(clients);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("clients/{id}")]
        public async Task<IActionResult> GetClientById([FromRoute]int id)
        {
            try
            {
                var client = await Task.Run(() => _clientService.GetClientById(id));
                if (client is null) return NotFound("Client not found");
                return Ok(client);
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
