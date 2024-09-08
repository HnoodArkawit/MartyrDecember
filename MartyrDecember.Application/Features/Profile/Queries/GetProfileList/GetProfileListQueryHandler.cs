using AutoMapper;
using MartyrDecember.Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartyrDecember.Application.Features.Profile.Queries.GetProfileList
{
    public class GetProfileListQueryHandler : IRequestHandler<GetProfileListQuery, List<GetProfileListViewModel>>
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IMapper _mapper;

        public GetProfileListQueryHandler(IProfileRepository profileRepository, IMapper mapper)
        {
            _profileRepository = profileRepository;
            _mapper = mapper;
        }
        public async Task<List<GetProfileListViewModel>> Handle(GetProfileListQuery request, CancellationToken cancellationToken)
        {
            var allPosts = await _profileRepository.GetAllProfileAsync(/*true*/);
            return _mapper.Map<List<GetProfileListViewModel>>(allPosts);
        }
    }
}
