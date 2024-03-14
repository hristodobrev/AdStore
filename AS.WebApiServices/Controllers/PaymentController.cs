using AS.ApplicationServices.Interfaces;
using AS.ApplicationServices.RequestModels.Payment;
using AS.ApplicationServices.RequestModels.User;
using AS.ApplicationServices.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AS.WebApiServices.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly IUserService _userService;
        public PaymentController(IPaymentService paymentService, IUserService userService)
        {
            this._paymentService = paymentService;
            this._userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(PaymentRequestModel model)
        {
            if (await this._paymentService.MakePayment(model))
            {
                PatchUserRequestModel userModel = new PatchUserRequestModel()
                {
                    Id = User.GetUserId(),
                    IsPremium = true
                };

                await this._userService.PatchAsync(userModel);

                return Ok();
            }

            return BadRequest("Payment could not be processed");
        }
    }
}
