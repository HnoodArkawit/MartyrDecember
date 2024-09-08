using MartyrDecember.Domain;
using MartyrDecember_Application.Contracts;
using Microsoft.EntityFrameworkCore;

namespace MartyrDecember.Persistence.Repositories
{
    public class MarPicRepository : BaseRepository<MarPic>, IMarPicRepository
    {
        public MarPicRepository(MartyrDecemberDbContext martyrDbContext) : base(martyrDbContext)
        {

        }
        public async Task<IReadOnlyList<MarPic>> GetAllMartyrPicturesAsync()
        {
            List<MarPic> allMarPic = new List<MarPic>();
            allMarPic =await _dbContext.MarPics.ToListAsync();
            return allMarPic;
        }

        public async Task<MarPic> GetMartyrPictureByIdAsync(Guid id)
        {
            MarPic MarPic = new MarPic();
            MarPic =  await GetByIdAsync(id);
            return MarPic;
        }

    }
}
