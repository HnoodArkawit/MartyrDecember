using MartyrDecember.Application.Contracts;
using MartyrDecember.Domain;
using Microsoft.EntityFrameworkCore;

namespace MartyrDecember.Persistence.Repositories
{
    public class MarVidRepository : BaseRepository<MarVid>, IMarVidRepository
    {
        public MarVidRepository(MartyrDecemberDbContext martyrDbContext) : base(martyrDbContext)
        {

        }
        public async Task<IReadOnlyList<MarVid>> GetAllMartyrVideoAsync()
        {
            List<MarVid> allMarVid = new List<MarVid>();
            allMarVid = await _dbContext.MarVids.ToListAsync();
            return allMarVid;
        }

        public async Task<MarVid> GetMartyrVideoByIdAsync(Guid id)
        {
            MarVid MarVids = new MarVid();
            MarVids = await GetByIdAsync(id);
            return MarVids;
        }

    }
}
