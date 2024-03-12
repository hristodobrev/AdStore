using System.ComponentModel.DataAnnotations;

namespace AS.ApplicationServices.RequestModels.Ad
{
    public class UpdateAdRequestModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [StringLength(1000)]
        public string? Description { get; set; }
        [Required]
        [Range(0, 99999)]
        public decimal Price { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public bool IsSold { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
