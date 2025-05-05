using API.Models;
using System.Linq.Expressions;

namespace API.Repository.IRepository
{
    public interface UnitxQuery
    {
        Task<List<Unitx>> GetAll(Expression<Func<Unitx>>? filter = null, bool tracked = true);
        Task<Unitx> Get(Expression<Func<Unitx>>? filter = null, bool tracked = true);

    }
}
