using MartyrDecember.Damain;
using MartyrDecember.Domain;

namespace MartyrDecember_Application.Contracts
{
    public interface IAsyncRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<T> GetByIdAsync(Guid id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        IEnumerable<T> Search();
        List<MarPic> GetDataByUser(string UserId);
        List<MarVid> GetVidDataByUser(string UserId);
        List<SayMartyrs> GetSayDataByUser(string UserId);

    }
}
