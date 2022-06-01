using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealSupervisor.Interface;

namespace RealSupervisor.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }


        [HttpGet("clients")]
        public async Task<IResult> GetAllPayments()
        {
            return Results.Ok(await _clientService.GetAllClient());
        }
    }
}
