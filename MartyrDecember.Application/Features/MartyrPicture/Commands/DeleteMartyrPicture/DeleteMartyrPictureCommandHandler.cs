using MartyrDecember_Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartyrDecember_Application.Features.MartyrPicture.Commands.DeleteMartyrPicture
{
    public class DeleteMartyrPictureCommandHandler : IRequestHandler<DeleteMartyrPictureCommand>
    {
        private readonly IMarPicRepository _marPicRepository;
        public DeleteMartyrPictureCommandHandler(IMarPicRepository marPicRepository)
        {
            _marPicRepository = marPicRepository;
        }

        public async Task<Unit> Handle(DeleteMartyrPictureCommand request, CancellationToken cancellationToken)
        {
            var post = await _marPicRepository.GetByIdAsync(request.MarPicId);

            await _marPicRepository.DeleteAsync(post);

            return Unit.Value;
        }
    }
}
