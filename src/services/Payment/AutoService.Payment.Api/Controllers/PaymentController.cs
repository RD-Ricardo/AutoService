using AutoService.Core.Web.Helpers;
using AutoService.Payment.Application.InputModels;
using AutoService.Payment.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoService.Payment.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPaymentsAndTransactions()
        {
            var result = await _paymentService.GetPayments(this.ReturnUserId());

            if (!result.Any()) return BadRequest();

            return Ok(result);
        }

        [HttpGet("Transations")]
        public async Task<IActionResult> GetTransactions()
        {
            var result = await _paymentService.GetTransactionsByProfessional(this.ReturnUserId());

            if (!result.Any()) return BadRequest();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PaymentInputModel model)
        {
            var result = await _paymentService.ExecutePayment(model);

            if (!result) return BadRequest();
            
            return Ok(result);
        }
    }
}
