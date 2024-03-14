using AS.ApplicationServices.Interfaces;
using AS.ApplicationServices.RequestModels.Payment;

namespace AS.ApplicationServices.Implementations
{
    public class PaymentService : IPaymentService
    {
        public Task<bool> MakePayment(PaymentRequestModel model)
        {
            // Simulate a request
            Thread.Sleep(new Random().Next(2000));

            if (model.CardNumber == "1111111111111111" && model.CVC == "123" && model.CardOwner == "Hristo Dobrev")
            {
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }
    }
}
