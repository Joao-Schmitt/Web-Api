using System.Threading.Tasks;

namespace Gear.Domain.Interfaces.Generic
{
    public interface IUnitOfWork
    {
        bool SaveChanges();
        Task<bool> SaveChangesAsync();
    }
}
