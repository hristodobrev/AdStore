using System.ComponentModel.DataAnnotations;

namespace AS.ApplicationServices.RequestModels.User
{
    public class PatchUserRequestModel
    {
        [Required]
        public int Id { get; set; }
        public bool IsPremium { get; set; }
    }
}
