using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealSupervisor.Interface;
using RealSupervisor.Models;

namespace RealSupervisor.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private string uri = "https://localhost:7046/api/Payment/";
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet("payments/{id}")]
        public async Task<IResult> GetPayment(int id)
        {
            var response = await _paymentService.GetPaymentById(id);
            return Results.Ok(response);
        }

        [HttpGet("payments")]
        public async Task<IResult> GetAllPayments()
        {
            return Results.Ok(await _paymentService.GetAllPayments());
        }

        [HttpPost("makePayment")]
        public async Task<IActionResult> CreatePayment([FromBody]Payment payment)
        {
            var newPayment = await Task.Run(() => _paymentService.CreatePayment(payment));
            return Created(uri+"makePayment",newPayment);
        }
    }
}
