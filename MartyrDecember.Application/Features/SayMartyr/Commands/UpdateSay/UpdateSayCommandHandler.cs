using AutoMapper;
using MartyrDecember.Damain;
using MartyrDecember_Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartyrDecember.Application.Features.SayMartyr.Commands.UpdateSay
{
    public class UpdateSayCommandHandler : IRequestHandler<UpdateSayCommand>
    {
        private readonly IAsyncRepository<SayMartyrs> _sayRepository;
        private readonly IMapper _mapper;
        public UpdateSayCommandHandler(IAsyncRepository<SayMartyrs> sayRepository, IMapper mapper)
        {
            _sayRepository = sayRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateSayCommand request, CancellationToken cancellationToken)
        {
            SayMartyrs marVid = _mapper.Map<SayMartyrs>(request);

            await _sayRepository.UpdateAsync(marVid);

            return Unit.Value;
        }

    }

}
