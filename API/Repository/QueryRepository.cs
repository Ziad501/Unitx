using API.Data;
using API.Models;
using API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace API.Repository
{
    public class QueryRepository<T> : IQueryRepository<T> where T : class
    {
        private readonly AppDbContext _db;
        private readonly DbSet<T> _dbset;
        public QueryRepository(AppDbContext context)
        {
            _db = context;
            _dbset = _db.Set<T>() ;
        }
        public async Task<T> GetAsync(Expression<Func<T, bool>>? filter = null , bool tracked = true)
        {
            var query = _dbset.AsQueryable();

            if (!tracked) { query = query.AsNoTracking(); }
            if (filter != null) { query = query.Where(filter); }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter =null)
        {
            var query = _dbset.AsQueryable();
            if(filter != null)
            query = query.Where(filter);

            return await query.ToListAsync();

        }
    }
}
