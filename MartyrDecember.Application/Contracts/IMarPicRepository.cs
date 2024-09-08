using MartyrDecember.Domain;

namespace MartyrDecember_Application.Contracts
{
    public interface IMarPicRepository : IAsyncRepository<MarPic>
    {
        Task<IReadOnlyList<MarPic>> GetAllMartyrPicturesAsync();
        Task<MarPic> GetMartyrPictureByIdAsync(Guid MarPicId);
    }
}
