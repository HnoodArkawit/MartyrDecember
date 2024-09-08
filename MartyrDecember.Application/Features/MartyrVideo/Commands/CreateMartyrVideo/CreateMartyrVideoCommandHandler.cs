using AutoMapper;
using MartyrDecember.Application.Contracts;
using MartyrDecember.Domain;
using MediatR;

namespace MartyrDecember.Application.Features.MartyrVideo.Commands.CreateMartyrVideo
{
    public class CreateMartyrVideoCommandHandler : IRequestHandler<CreateMartyVideoCommand, Guid>
    {
        private readonly IMarVidRepository _martyrVideoRepository;
        private readonly IMapper _mapper;

        public CreateMartyrVideoCommandHandler(IMarVidRepository martyrVideoRepository, IMapper mapper)
        {
            _martyrVideoRepository = martyrVideoRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateMartyVideoCommand request, CancellationToken cancellationToken)
        {
            MarVid martyrVideo = _mapper.Map<MarVid>(request);

            CreateCommandValidator validator = new CreateCommandValidator();
            var result = await validator.ValidateAsync(request);

            if (result.Errors.Any())
            {
                throw new Exception("Video is not valid");
            }

            martyrVideo = await _martyrVideoRepository.AddAsync(martyrVideo);

            return martyrVideo.MarVidId;
        }


    }
}
