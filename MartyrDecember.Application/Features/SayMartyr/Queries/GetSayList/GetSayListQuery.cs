using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartyrDecember.Application.Features.SayMartyr.Queries.GetSayList
{
    public class GetSayListQuery : IRequest<List<GetSayListViewModel>>
    {

    }
}
