using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartyrDecember.Application.Features.MartyrVideo.Commands.DeleteMartyrVideo
{
    public class DeleteMartyrVideoCommand : IRequest
    {
        public Guid MarVidId { get; set; }

    }
}
