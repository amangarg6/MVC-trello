﻿using System.ComponentModel.DataAnnotations;

namespace ProjectTask.Models.Vm
{
    public class LoginVM
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
