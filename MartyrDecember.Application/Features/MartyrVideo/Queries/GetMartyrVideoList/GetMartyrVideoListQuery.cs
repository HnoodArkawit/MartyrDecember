using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartyrDecember.Application.Features.MartyrVideo.Queries.GetMartyrVideoList
{
    public class GetMartyrVideoListQuery : IRequest<List<GetMartyrVideoListViewModel>>
    {
    }
}
