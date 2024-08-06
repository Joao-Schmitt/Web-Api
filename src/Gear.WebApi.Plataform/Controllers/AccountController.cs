using Gear.Application.ViewModels;
using Gear.Domain.Interfaces;
using Gear.Domain.Interfaces.Generic;
using Gear.Domain.Notifications;
using Gear.WebApi.Plataform.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gear.WebApi.Plataform.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ApiController
    {
        private IUserRepository _userRepository;
        private readonly IUnitOfWork _uow;
        public AccountController(NotificationHandler notifications, IUserRepository userRepository, IUnitOfWork uow) : base(notifications)
        {
            _userRepository = userRepository;
            _uow = uow;
        }

        [HttpPost]
        public IActionResult Login(UserViewModel user)
        {
            try
            {
                if (user == null)
                    return ResponseError("Usuário inválido!");

                if (string.IsNullOrWhiteSpace(user.Email) || string.IsNullOrWhiteSpace(user.Password))
                    return ResponseError("Email e/ou senha inválidos!");

                var logginUser = this._userRepository.GetByEmail(user.Email);

                if (logginUser == null)
                    return ResponseError("O usuário não existe!");

                if (Domain.Security.ToSHA512(user.Password) != logginUser.Password)
                    return ResponseError("Senha inválida!");


                return ResponseOK(new LoginResult()
                {
                    Id = logginUser.Id,
                });
            }
            catch(Exception ex)
            {
                return ResponseError(ex.ToString());    
            }
        }

        [HttpPost]
        public IActionResult CreateAccount(CreateAccountRequest account)
        {
            try
            {
                if(account == null)
                    return ResponseError("Dados inválidos inválidos!");

                if(string.IsNullOrWhiteSpace(account.Email) || string.IsNullOrWhiteSpace(account.Password))
                    return ResponseError("Email e/ou senha inválidos!");

                var user = this._userRepository.GetByEmail(account.Email);

                if (user != null)
                    return ResponseError("Usuário já cadastrado!");

                this._userRepository.Create(new Domain.Entities.UsersCredentials()
                {
                     Email = account.Email,
                     Password = Domain.Security.ToSHA512(account.Password)
                });

                if (!this._uow.SaveChanges())
                {
                    return ResponseError("Erro ao tentar cadastrar o usuário!");
                }

                var logginUser = this._userRepository.GetByEmail(account.Email);
                    
                return ResponseOK(new LoginResult()
                {
                    Id = logginUser.Id
                });
            }
            catch (Exception ex) 
            {
                return ResponseError(ex.Message);
            }
        }
    }
}
