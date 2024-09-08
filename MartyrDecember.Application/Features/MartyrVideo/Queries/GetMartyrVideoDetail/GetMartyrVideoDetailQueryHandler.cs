using AutoMapper;
using MartyrDecember.Application.Contracts;
using MartyrDecember.Application.Features.MartyrVideo.Queries.GetMartyrVideoList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartyrDecember.Application.Features.MartyrVideo.Queries.GetMartyrVideoDetail
{
    public class GetMartyrVideoDetailQueryHandler : IRequestHandler<GetMartyrVideoDetailQuery, GetMartyrVideoDetailViewModel>
    {
        private readonly IMarVidRepository _marVidRepository;
        private readonly IMapper _mapper;

        public GetMartyrVideoDetailQueryHandler(IMarVidRepository marVidRepository, IMapper mapper)
        {
            _marVidRepository = marVidRepository;
            _mapper = mapper;
        }
        public async Task<GetMartyrVideoDetailViewModel> Handle(GetMartyrVideoDetailQuery request, CancellationToken cancellationToken)
        {
            var Post = await _marVidRepository.GetMartyrVideoByIdAsync(request.MarVidId/*, true*/);

            return _mapper.Map<GetMartyrVideoDetailViewModel>(Post);
        }
    }
}
