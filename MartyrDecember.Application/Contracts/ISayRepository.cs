using MartyrDecember.Damain;
using MartyrDecember_Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartyrDecember.Application.Contracts
{
    public interface ISayRepository : IAsyncRepository<SayMartyrs>
    {
        Task<IReadOnlyList<SayMartyrs>> GetAllSayAsync();
        Task<SayMartyrs> GetSayByIdAsync(Guid SayId);


    }
}
