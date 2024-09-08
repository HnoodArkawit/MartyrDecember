using AutoMapper;
using MartyrDecember.Application.Contracts;
using MartyrDecember.Damain;
using MartyrDecember.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartyrDecember.Application.Features.Profile.Commands.CreateProfile
{
    public class CreateProfileCommandHandler : IRequestHandler<CreateProfileCommand, Guid>
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IMapper _mapper;

        public CreateProfileCommandHandler(IProfileRepository profileRepository, IMapper mapper)
        {
            _profileRepository = profileRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateProfileCommand request, CancellationToken cancellationToken)
        {
            ProfilePicture profile = _mapper.Map<ProfilePicture>(request);

            CreateCommandValidator validator = new CreateCommandValidator();
            var result = await validator.ValidateAsync(request);

            if (result.Errors.Any())
            {
                throw new Exception("Profile is not valid");
            }

            profile = await _profileRepository.AddAsync(profile);

            return profile.ProfileId;
        }


    }
}
