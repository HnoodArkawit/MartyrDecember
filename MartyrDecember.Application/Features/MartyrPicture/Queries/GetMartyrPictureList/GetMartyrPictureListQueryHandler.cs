using AutoMapper;
using MartyrDecember_Application.Contracts;
using MediatR;

namespace MartyrDecember_Application.Features.MartyrPicture.Queries.GetMartyrPictureList
{
    public class GetMartyrPictureListQueryHandler : IRequestHandler<GetMartyrPictureListQuery, List<GetMartyrPictureListViewModel>>
    {
        private readonly IMarPicRepository _postRepository;
        private readonly IMapper _mapper;

        public GetMartyrPictureListQueryHandler(IMarPicRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public async Task<List<GetMartyrPictureListViewModel>> Handle(GetMartyrPictureListQuery request, CancellationToken cancellationToken)
        {
            var allPosts = await _postRepository.GetAllMartyrPicturesAsync();
            return _mapper.Map<List<GetMartyrPictureListViewModel>>(allPosts);
        }
    }
}
