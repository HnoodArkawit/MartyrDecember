using AutoMapper;
using MartyrDecember.Domain;
using MartyrDecember_Application.Contracts;
using MediatR;

namespace MartyrDecember_Application.Features.MartyrPicture.Commands.CreateMartyrPicture
{
    public class CreateMartyrPictureCommandHandler : IRequestHandler<CreateMartyrPictureCommand, Guid>
    {
        private readonly IMarPicRepository _martyrPictureRepository;
        private readonly IMapper _mapper;

        public CreateMartyrPictureCommandHandler(IMarPicRepository martyrPictureRepository, IMapper mapper)
        {
            _martyrPictureRepository = martyrPictureRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateMartyrPictureCommand request, CancellationToken cancellationToken)
        {
            MarPic martyrPicture = _mapper.Map<MarPic>(request);

            CreateCommandValidator validator = new CreateCommandValidator();
            var result = await validator.ValidateAsync(request);

            if (result.Errors.Any())
            {
                throw new Exception("Post is not valid");
            }

            martyrPicture = await _martyrPictureRepository.AddAsync(martyrPicture);

            return martyrPicture.MarPicId;
        }


    }
}
