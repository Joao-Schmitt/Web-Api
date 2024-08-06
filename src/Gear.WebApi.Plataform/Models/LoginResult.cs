using Gear.Domain.Enumerators;

namespace Gear.WebApi.Plataform.Models
{
    public class LoginResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UserType UserType { get; set; }
    }
}
