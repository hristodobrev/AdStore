using System.ComponentModel.DataAnnotations;

namespace AS.ApplicationServices.RequestModels.Category
{
    public class UpdateCategoryRequestModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int RatingGained { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int RequiredRating { get; set; }
        [Required]
        public bool IsRequiringPremium { get; set; }
    }
}
