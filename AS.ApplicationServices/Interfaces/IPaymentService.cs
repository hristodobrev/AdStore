using AS.ApplicationServices.RequestModels.Payment;

namespace AS.ApplicationServices.Interfaces
{
    public interface IPaymentService
    {
        public Task<bool> MakePayment(PaymentRequestModel model);
    }
}
