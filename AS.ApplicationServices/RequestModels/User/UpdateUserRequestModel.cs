﻿using System.ComponentModel.DataAnnotations;

namespace AS.ApplicationServices.RequestModels.User
{
    public class UpdateUserRequestModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
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
        public bool IsPremium { get; set; }
    }
}
