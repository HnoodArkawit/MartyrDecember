using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartyrDecember.Application.Features.Profile.Commands.DeleteProfile
{
    public class DeleteProfileCommand : IRequest
    {
        public Guid ProfileId { get; set; }

    }
}
