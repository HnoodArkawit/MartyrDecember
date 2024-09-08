using FluentValidation;

namespace MartyrDecember_Application.Features.MartyrPicture.Commands.CreateMartyrPicture
{
    public class CreateCommandValidator : AbstractValidator<CreateMartyrPictureCommand>
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

            RuleFor(p => p.ImageUrl)
               .NotEmpty()
               .NotNull();

        }

    }
}
