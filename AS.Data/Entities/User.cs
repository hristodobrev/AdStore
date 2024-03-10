using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AS.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [StringLength(100)]
        public string FirstName { get; set; }
        [StringLength(100)]
        public string LastName { get; set; }
        [Required]
        [Range(0, 100)]
        public int Age { get; set; }
        [Required]
        [StringLength(50)]
        public string Town { get; set; }
        public int Rating { get; set; }
        public bool IsPremium { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DateCreated { get; set; }
    }
}


/*
 
user:
 - username varchar(100)
 - password varchar(50)
 - firstName varchar(100)
 - lastName varchar(100)
 - age int
 - town varchar(50)
 - rating int
 - isPremium bit
 - dateCreated datetime
 
 */