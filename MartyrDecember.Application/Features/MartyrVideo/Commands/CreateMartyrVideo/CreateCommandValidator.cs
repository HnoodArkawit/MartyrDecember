using FluentValidation;

namespace MartyrDecember.Application.Features.MartyrVideo.Commands.CreateMartyrVideo
{
    public class CreateCommandValidator : AbstractValidator<CreateMartyVideoCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(p => p.MartyrName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100);

            RuleFor(p => p.Description)
                .NotEmpty()
                .NotNull();

            RuleFor(p => p.VideoUrl)
               .NotEmpty()
               .NotNull();

        }

    }
}
