using Gear.Domain.Entities;
using Gear.Domain.Interfaces;
using Gear.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gear.Infrastructure.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(GearContext context) : base(context)
        {

        }

        public User GetByEmail(string email)
        {
            return base.GetAll(x => x.Email == email).FirstOrDefault();
        }
    }
}
