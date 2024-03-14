using System.ComponentModel.DataAnnotations;

namespace AS.ApplicationServices.RequestModels.Payment
{
    public class PaymentRequestModel
    {
        [Required]
        public string CardOwner { get; set; }
        [Required]
        [StringLength(maximumLength: 16, MinimumLength = 16)]
        public string CardNumber { get; set; }
        [Required]
        [StringLength(maximumLength: 3, MinimumLength = 3)]
        public string CVC { get; set; }
    }
}
