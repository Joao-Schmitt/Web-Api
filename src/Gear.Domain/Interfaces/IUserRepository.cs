using Gear.Domain.Entities;
using Gear.Domain.Interfaces.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gear.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        public User GetByEmail(string email);
    }
}
