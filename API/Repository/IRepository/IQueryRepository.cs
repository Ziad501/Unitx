using API.Models;
using System.Linq.Expressions;

namespace API.Repository.IRepository
{
    public interface IQueryRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);
        Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true);

    }
}
