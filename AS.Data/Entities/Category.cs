using System.ComponentModel.DataAnnotations;

namespace AS.Data.Entities
{
    public class Category
    {
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
        public DateTime DateCreated { get; set; }
    }
}