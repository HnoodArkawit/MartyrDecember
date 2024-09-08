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
    public class SayRepository : BaseRepository<SayMartyrs>, ISayRepository
    {
        public SayRepository(MartyrDecemberDbContext martyrDbContext) : base(martyrDbContext)
        {

        }
        public async Task<IReadOnlyList<SayMartyrs>> GetAllSayAsync()
        {
            List<SayMartyrs> allSay = new List<SayMartyrs>();
            allSay =await _dbContext.SayMartyrs.ToListAsync();
            return allSay;
        }

        public async Task<SayMartyrs> GetSayByIdAsync(Guid id)
        {
            SayMartyrs SayMartyrs = new SayMartyrs();
            SayMartyrs =await GetByIdAsync(id);
            return SayMartyrs;
        }

    }
}

