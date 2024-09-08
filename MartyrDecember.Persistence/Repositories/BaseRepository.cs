using MartyrDecember.Damain;
using MartyrDecember.Domain;
using MartyrDecember_Application.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MartyrDecember.Persistence.Repositories
{
    public partial class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly MartyrDecemberDbContext _dbContext;

        public BaseRepository(MartyrDecemberDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }
        public IEnumerable<T> Search()
        {
            return _dbContext.Set<T>().ToList();
        }
        public List<MarPic> GetDataByUser(string UserId)
        {
                return _dbContext.MarPics.Where(x => x.UserId == UserId).ToList();
        }
        public List<SayMartyrs> GetSayDataByUser(string UserId)
        {
            return _dbContext.SayMartyrs.Where(x => x.UserId == UserId).ToList();
        }
        public List<MarVid> GetVidDataByUser(string UserId)
        {
            return _dbContext.MarVids.Where(x => x.UserId == UserId).ToList();
        }


    }
}
