using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartyrDecember.Application.Features.SayMartyr.Commands.DeleteSay
{
    public class DeleteSayCommand : IRequest
    {
        public Guid SayId { get; set; }

    }
}
