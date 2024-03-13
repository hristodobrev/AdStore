﻿using System.ComponentModel.DataAnnotations;

namespace AS.ApplicationServices.RequestModels.Auth
{
    public class LoginRequestModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
