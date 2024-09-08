using MartyrDecember.Application.Contracts;
using MartyrDecember.Damain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartyrDecember.Persistence.Repositories
{
    public class ProfileRepository : BaseRepository<ProfilePicture>, IProfileRepository
    {
        public ProfileRepository(MartyrDecemberDbContext martyrDbContext) : base(martyrDbContext)
        {

        }
        public async Task<IReadOnlyList<ProfilePicture>> GetAllProfileAsync()
        {
            List<ProfilePicture> allProfile = new List<ProfilePicture>();
            allProfile = await _dbContext.ProfilePictures.ToListAsync();
            return allProfile;
        }

        public async Task<ProfilePicture> GetProfilePictureByIdAsync(Guid MarPicId)
        {
            ProfilePicture ProfilePictures = new ProfilePicture();
            ProfilePictures =  await GetByIdAsync(MarPicId);
            return ProfilePictures;
        }

    }
}