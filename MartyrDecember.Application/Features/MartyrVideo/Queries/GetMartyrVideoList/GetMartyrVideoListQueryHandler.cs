using AutoMapper;
using MartyrDecember.Application.Contracts;
using MediatR;

namespace MartyrDecember.Application.Features.MartyrVideo.Queries.GetMartyrVideoList
{
    public class GetMartyrVideoListQueryHandler : IRequestHandler<GetMartyrVideoListQuery, List<GetMartyrVideoListViewModel>>
    {
        private readonly IMarVidRepository _vidRepository;
        private readonly IMapper _mapper;

        public GetMartyrVideoListQueryHandler(IMarVidRepository vidRepository, IMapper mapper)
        {
            _vidRepository = vidRepository;
            _mapper = mapper;
        }
        public async Task<List<GetMartyrVideoListViewModel>> Handle(GetMartyrVideoListQuery request, CancellationToken cancellationToken)
        {
            var allPosts = await _vidRepository.GetAllMartyrVideoAsync();
            return _mapper.Map<List<GetMartyrVideoListViewModel>>(allPosts);
        }
    }
}
