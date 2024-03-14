using System.ComponentModel.DataAnnotations;

namespace AS.ApplicationServices.RequestModels.Auth
{
    public class RegisterRequestModel
    {
        [Required]
        [StringLength(100)]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [StringLength(100)]
        public string? FirstName { get; set; }
        [StringLength(100)]
        public string? LastName { get; set; }
        [Required]
        [Range(0, 100)]
        public int Age { get; set; }
        [Required]
        [StringLength(50)]
        public string Town { get; set; }
    }
}
