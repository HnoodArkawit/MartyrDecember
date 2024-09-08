using MartyrDecember.Damain;
using MartyrDecember_Application.Contracts;

namespace MartyrDecember.Application.Contracts
{
    public interface IProfileRepository : IAsyncRepository<ProfilePicture>
    {
        Task<IReadOnlyList<ProfilePicture>> GetAllProfileAsync();
        Task<ProfilePicture> GetProfilePictureByIdAsync(Guid ProfileId);
    }
}
