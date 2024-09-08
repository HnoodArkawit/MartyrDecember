using AutoMapper;
using MartyrDecember.Application.Contracts;
using MediatR;

namespace MartyrDecember.Application.Features.Profile.Queries.GetProfileDetail
{
    public class GetProfilelQueryHandler : IRequestHandler<GetProfileDetailQuery, GetProfileDetailViewModel>
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IMapper _mapper;

        public GetProfilelQueryHandler(IProfileRepository profileRepository, IMapper mapper)
        {
            _profileRepository = profileRepository;
            _mapper = mapper;
        }
        public async Task<GetProfileDetailViewModel> Handle(GetProfileDetailQuery request, CancellationToken cancellationToken)
        {
            var Post = await _profileRepository.GetProfilePictureByIdAsync(request.ProfilecId);

            return _mapper.Map<GetProfileDetailViewModel>(Post);
        }
    }

}
