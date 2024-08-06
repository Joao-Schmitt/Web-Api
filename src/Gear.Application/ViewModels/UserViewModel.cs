using Gear.Domain.Enumerators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Gear.Application.ViewModels
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Email é obrigatório!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória!")]
        public string Password { get; set; }
        public UserType UserType { get; set; }
    }
}
