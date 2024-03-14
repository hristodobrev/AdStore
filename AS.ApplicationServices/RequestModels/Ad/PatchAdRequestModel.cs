using System.ComponentModel.DataAnnotations;

namespace AS.ApplicationServices.RequestModels.Ad
{
    public class PatchAdRequestModel
    {
        [Required]
        public int Id { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsSold { get; set; }
    }
}
