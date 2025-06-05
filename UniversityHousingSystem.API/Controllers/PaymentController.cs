using MediatR;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using UniversityHousingSystem.API.APIBases;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : AppController
    {
        private readonly IPaymentService _paymentService;
        private readonly string _webHookSecret;
        public PaymentController(IMediator mediator, IPaymentService paymentService, IConfiguration configuration) : base(mediator)
        {
            _paymentService = paymentService;
            _webHookSecret = configuration["StripeSettings:webHookSecret"];
        }

        #region Queries
        //[HttpGet("{code}")] // GET: /api/payment/{code}
        //[ProducesResponseType(typeof(StudentRegistrationCode), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<ActionResult<StudentRegistrationCode>> CreateOrUpdatePaymentIntent(string code)
        //{
        //    var result = await _paymentService.CreateOrUpdatePaymentIntent(code);
        //    if (result == null)
        //    {
        //        return NotFound(new { Message = "Registration code not found or already paid/used." });
        //    }
        //    return Ok(result);
        //}
        #endregion
        #region Commands
        [HttpPost("webhook")] // POST: /api/payment/webhook
        public async Task<IActionResult> HandleWebhookAsync()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

            try
            {
                var stripeEvent = EventUtility.ConstructEvent(
                    json,
                    Request.Headers["Stripe-Signature"],
                    _webHookSecret
                );

                // Handle the event
                var paymentIntent = stripeEvent.Data.Object as PaymentIntent;
                switch (stripeEvent.Type)
                {
                    case "payment_intent.succeeded":
                        await _paymentService.UpdatePaymentStatus(paymentIntent.Id, true);
                        break;
                    case "payment_intent.failed":
                        await _paymentService.UpdatePaymentStatus(paymentIntent.Id, false);
                        break;
                }

                return Ok();
            }
            catch (StripeException e)
            {
                return BadRequest(e.Message);
            }
        }
        #endregion
    }
}
