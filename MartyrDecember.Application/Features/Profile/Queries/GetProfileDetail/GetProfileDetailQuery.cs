using MartyrDecember_Application.Features.MartyrPicture.Queries.GetMartyrPictureDetail;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartyrDecember.Application.Features.Profile.Queries.GetProfileDetail
{
    public class GetProfileDetailQuery : IRequest<GetProfileDetailViewModel>
    {
        public Guid ProfilecId { get; set; }
    }

}
