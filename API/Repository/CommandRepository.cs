using API.Data;
using API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class CommandRepository<T> : ICommandRepository<T> where T : class
    {
        private readonly AppDbContext _db;
        private readonly DbSet<T> _dbset;
        public CommandRepository(AppDbContext db)
        {
            _db = db;
            _dbset = db.Set<T>();
        }
        public async Task CreateAsync(T unit)
        {
            await _dbset.AddAsync(unit);
            await SaveAsync();
        }

        public async Task DeleteAsync(T unit)
        {
            _dbset.Remove(unit);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
        public async Task UpdateAsync(T unit)
        {
            _dbset.Update(unit);
            await SaveAsync();
        }
    }
}
