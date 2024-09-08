using MartyrDecember.Application.Features.Profile.Queries.GetProfileDetail;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartyrDecember.Application.Features.SayMartyr.Queries.GetSayDetail
{
    public class GetSayDetailQuery : IRequest<GetSayDetailViewModel>
    {
        public Guid SayId { get; set; }

    }
}
