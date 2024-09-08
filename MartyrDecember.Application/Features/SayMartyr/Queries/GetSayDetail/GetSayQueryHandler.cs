using AutoMapper;
using MartyrDecember.Application.Contracts;
using MediatR;

namespace MartyrDecember.Application.Features.SayMartyr.Queries.GetSayDetail
{
    public class GetSayQueryHandler : IRequestHandler<GetSayDetailQuery, GetSayDetailViewModel>
    {
        private readonly ISayRepository _sayRepository;
        private readonly IMapper _mapper;

        public GetSayQueryHandler(ISayRepository sayRepository, IMapper mapper)
        {
            _sayRepository = sayRepository;
            _mapper = mapper;
        }
        public async Task<GetSayDetailViewModel> Handle(GetSayDetailQuery request, CancellationToken cancellationToken)
        {
            var Post = await _sayRepository.GetSayByIdAsync(request.SayId);

            return _mapper.Map<GetSayDetailViewModel>(Post);
        }
    }

}
