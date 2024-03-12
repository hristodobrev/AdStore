using System.ComponentModel.DataAnnotations;

namespace AS.Data.Entities
{
    public class Ad
    {
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
        public DateTime DateCreated { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}