﻿using System.ComponentModel.DataAnnotations;

namespace AS.ApplicationServices.RequestModels.User
{
    public class CreateUserRequestModel
    {
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
        public bool IsPremium { get; set; }
    }
}
