using MartyrDecember.Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartyrDecember.Application.Features.SayMartyr.Commands.DeleteSay
{
    public class DeleteSayCommandHandler : IRequestHandler<DeleteSayCommand>
    {
        private readonly ISayRepository _sayRepository;
        public DeleteSayCommandHandler(ISayRepository sayRepository)
        {
            _sayRepository = sayRepository;
        }

        public async Task<Unit> Handle(DeleteSayCommand request, CancellationToken cancellationToken)
        {
            var post = await _sayRepository.GetByIdAsync(request.SayId);

            await _sayRepository.DeleteAsync(post);

            return Unit.Value;
        }
    }
}
