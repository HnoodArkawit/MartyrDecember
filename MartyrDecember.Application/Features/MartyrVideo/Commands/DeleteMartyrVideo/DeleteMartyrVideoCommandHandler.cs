using MartyrDecember.Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartyrDecember.Application.Features.MartyrVideo.Commands.DeleteMartyrVideo
{
    public class DeleteMartyrVideoCommandHandler : IRequestHandler<DeleteMartyrVideoCommand>
    {
        private readonly IMarVidRepository _marVidRepository;
        public DeleteMartyrVideoCommandHandler(IMarVidRepository marVidRepository)
        {
            _marVidRepository = marVidRepository;
        }

        public async Task<Unit> Handle(DeleteMartyrVideoCommand request, CancellationToken cancellationToken)
        {
            var post = await _marVidRepository.GetByIdAsync(request.MarVidId);

            await _marVidRepository.DeleteAsync(post);

            return Unit.Value;
        }
    }
}
