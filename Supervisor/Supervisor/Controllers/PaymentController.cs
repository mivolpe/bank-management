using Bank.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Supervisor.Models;
using System.Net;

namespace Bank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private string uri = "https://localhost:7177/api/Payment/";

        public PaymentController (IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [Authorize(Roles = "Manager")]
        [HttpGet("payments")]
        public async Task<IActionResult> GetPayments()
        {
            try
            {
                var payments = await Task.Run(() => _paymentService.GetAllPayments());
                return Ok(payments);
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize(Roles = "Manager")]
        [HttpGet("payments/{id}")]
        public async Task<IActionResult> GetPayment(int id)
        {
            try
            {
                var payment = await Task.Run(() => _paymentService.GetPaymentById(id));
                if (payment is null) return NotFound("Payment not found");
                return Ok(payment);
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        //[Authorize(Roles = "Manager,Client")]
        [HttpPost("makePayment")]
        public async Task<IActionResult> AddPayment([FromBody] Payment payment)
        {
            try
            {
                var newPayment = await Task.Run(() => _paymentService.CreatePayment(payment));
                return Created(uri+"makePayment",newPayment);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
