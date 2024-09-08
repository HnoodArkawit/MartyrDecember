using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartyrDecember.Application.Features.Profile.Queries.GetProfileList
{
    public class GetProfileListQuery : IRequest<List<GetProfileListViewModel>>
    {
    }
}
