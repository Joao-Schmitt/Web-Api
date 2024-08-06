using System.ComponentModel.DataAnnotations;

namespace Gear.Application.ViewModels
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Email é obrigatório!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória!")]
        public string Password { get; set; }
    }
}
