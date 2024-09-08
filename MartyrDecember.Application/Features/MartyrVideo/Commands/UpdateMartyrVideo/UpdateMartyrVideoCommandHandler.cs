using AutoMapper;
using MartyrDecember.Domain;
using MartyrDecember_Application.Contracts;
using MediatR;

namespace MartyrDecember.Application.Features.MartyrVideo.Commands.UpdateMartyrVideo
{
    public class UpdateMartyrVideoCommandHandler : IRequestHandler<UpdateMartyrVideoCommand>
    {
        private readonly IAsyncRepository<MarVid> _vidRepository;
        private readonly IMapper _mapper;
        public UpdateMartyrVideoCommandHandler(IAsyncRepository<MarVid> vidRepository, IMapper mapper)
        {
            _vidRepository = vidRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateMartyrVideoCommand request, CancellationToken cancellationToken)
        {
            MarVid marVid = _mapper.Map<MarVid>(request);

            await _vidRepository.UpdateAsync(marVid);

            return Unit.Value;
        }

    }

}
