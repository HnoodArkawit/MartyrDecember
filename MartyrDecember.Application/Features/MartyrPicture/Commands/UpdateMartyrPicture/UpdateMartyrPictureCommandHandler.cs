using AutoMapper;
using MartyrDecember.Domain;
using MartyrDecember_Application.Contracts;
using MartyrDecember_Application.Features.MartyrPicture.Commands.UpdateMartyrPicture;
using MediatR;

namespace MartyrDecember.Application.Features.MartyrPicture.Commands.UpdateMartyrPicture
{
    public class UpdateMartyrPictureCommandHandler : IRequestHandler<UpdateMartyrPictureCommand>
    {
        private readonly IAsyncRepository<MarPic> _picRepository;
        private readonly IMapper _mapper;
        public UpdateMartyrPictureCommandHandler(IAsyncRepository<MarPic> picRepository, IMapper mapper)
        {
            _picRepository = picRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateMartyrPictureCommand request, CancellationToken cancellationToken)
        {
            MarPic marPic = _mapper.Map<MarPic>(request);

            await _picRepository.UpdateAsync(marPic);

            return Unit.Value;
        }

    }

}
