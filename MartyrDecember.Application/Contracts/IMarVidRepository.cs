using MartyrDecember.Domain;
using MartyrDecember_Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartyrDecember.Application.Contracts
{
    public interface IMarVidRepository : IAsyncRepository<MarVid>
    {
        Task<IReadOnlyList<MarVid>> GetAllMartyrVideoAsync();
        Task<MarVid> GetMartyrVideoByIdAsync(Guid MarVidId);

    }
}
