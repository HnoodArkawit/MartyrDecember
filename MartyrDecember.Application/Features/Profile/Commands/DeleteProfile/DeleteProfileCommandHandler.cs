using MartyrDecember.Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartyrDecember.Application.Features.Profile.Commands.DeleteProfile
{
    public class DeleteProfileCommandHandler : IRequestHandler<DeleteProfileCommand>
    {
        private readonly IProfileRepository _profileRepository;
        public DeleteProfileCommandHandler(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public async Task<Unit> Handle(DeleteProfileCommand request, CancellationToken cancellationToken)
        {
            var post = await _profileRepository.GetByIdAsync(request.ProfileId);

            await _profileRepository.DeleteAsync(post);

            return Unit.Value;
        }
    }
}
