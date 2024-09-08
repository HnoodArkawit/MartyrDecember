using AutoMapper;
using MartyrDecember.Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartyrDecember.Application.Features.SayMartyr.Queries.GetSayList
{
    public class GetSayListQueryHandler : IRequestHandler<GetSayListQuery, List<GetSayListViewModel>>
    {
        private readonly ISayRepository _sayRepository;
        private readonly IMapper _mapper;

        public GetSayListQueryHandler(ISayRepository sayRepository, IMapper mapper)
        {
            _sayRepository = sayRepository;
            _mapper = mapper;
        }
        public async Task<List<GetSayListViewModel>> Handle(GetSayListQuery request, CancellationToken cancellationToken)
        {
            var allPosts = await _sayRepository.GetAllSayAsync(/*true*/);
            return _mapper.Map<List<GetSayListViewModel>>(allPosts);
        }
    }
}
