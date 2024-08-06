using Gear.Domain.Enumerators;

namespace Gear.WebApi.Plataform.Models
{
    public class CreateAccountRequest
    {
        public string Name { get; set; }
        public int KeyPass { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserType UserType { get; set; }
    }
}
