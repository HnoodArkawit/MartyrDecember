using AutoMapper;
using MartyrDecember.Damain;
using MartyrDecember_Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartyrDecember.Application.Features.Profile.Commands.UpdateProfile
{
    public class UpdateProfileCommandHandler : IRequestHandler<UpdateProfileCommand>
    {
        private readonly IAsyncRepository<ProfilePicture> _profileRepository;
        private readonly IMapper _mapper;
        public UpdateProfileCommandHandler(IAsyncRepository<ProfilePicture> profileRepository, IMapper mapper)
        {
            _profileRepository = profileRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
        {
            ProfilePicture profilePicture = _mapper.Map<ProfilePicture>(request);

            await _profileRepository.UpdateAsync(profilePicture);

            return Unit.Value;
        }

    }

}
