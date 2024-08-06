using Gear.Domain.Interfaces.Generic;
using Gear.Infrastructure.Data.Context;
using System.Threading.Tasks;

namespace Gear.Infrastructure.Data.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GearContext _context;
        public UnitOfWork(GearContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
