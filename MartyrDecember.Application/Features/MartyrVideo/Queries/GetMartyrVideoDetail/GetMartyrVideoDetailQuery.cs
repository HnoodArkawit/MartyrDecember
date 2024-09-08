using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartyrDecember.Application.Features.MartyrVideo.Queries.GetMartyrVideoDetail
{
    public class GetMartyrVideoDetailQuery : IRequest<GetMartyrVideoDetailViewModel>
    {
        public Guid MarVidId { get; set; }
    }
}
