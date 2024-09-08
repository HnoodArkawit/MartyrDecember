using AutoMapper;
using MartyrDecember.Application.Contracts;
using MartyrDecember.Damain;
using MediatR;

namespace MartyrDecember.Application.Features.SayMartyr.Commands.CreateSay
{
    public class CreateSayCommandHandler : IRequestHandler<CreateSayMartyCommand, Guid>
    {
        private readonly ISayRepository _sayRepository;
        private readonly IMapper _mapper;

        public CreateSayCommandHandler(ISayRepository sayRepository, IMapper mapper)
        {
            _sayRepository = sayRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateSayMartyCommand request, CancellationToken cancellationToken)
        {
            SayMartyrs sayMartyr = _mapper.Map<SayMartyrs>(request);

            CreateCommandValidator validator = new CreateCommandValidator();
            var result = await validator.ValidateAsync(request);

            if (result.Errors.Any())
            {
                throw new Exception("SayMartyr is not valid");
            }

            sayMartyr = await _sayRepository.AddAsync(sayMartyr);

            return sayMartyr.SayId;
        }


    }
}
