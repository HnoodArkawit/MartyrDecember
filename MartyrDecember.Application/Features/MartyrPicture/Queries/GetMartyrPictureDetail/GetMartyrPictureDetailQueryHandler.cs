using AutoMapper;
using MartyrDecember_Application.Contracts;
using MediatR;

namespace MartyrDecember_Application.Features.MartyrPicture.Queries.GetMartyrPictureDetail
{
    public class GetMartyrPictureDetailQueryHandler : IRequestHandler<GetMartyrPictureDetailQuery, GetMartyrPictureDetailViewModel>
    {
        private readonly IMarPicRepository _marPicRepository;
        private readonly IMapper _mapper;

        public GetMartyrPictureDetailQueryHandler(IMarPicRepository marPicRepository, IMapper mapper)
        {
            _marPicRepository = marPicRepository;
            _mapper = mapper;
        }
        public async Task<GetMartyrPictureDetailViewModel> Handle(GetMartyrPictureDetailQuery request, CancellationToken cancellationToken)
        {
            var Post = await _marPicRepository.GetMartyrPictureByIdAsync(request.MarPicId);

            return _mapper.Map<GetMartyrPictureDetailViewModel>(Post);
        }
    }
}
