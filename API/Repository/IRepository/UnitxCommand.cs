using API.Models;

namespace API.Repository.IRepository
{
    public interface UnitxCommand
    {
        Task Create(Unitx unit);
        Task Delete(Unitx unit);
        Task Save();
    }
}
