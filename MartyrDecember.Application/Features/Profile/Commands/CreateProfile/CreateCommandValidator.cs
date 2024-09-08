using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartyrDecember.Application.Features.Profile.Commands.CreateProfile
{
    public class CreateCommandValidator : AbstractValidator<CreateProfileCommand>
    {
        public CreateCommandValidator()
        {

            RuleFor(p => p.ImageUrl)
               .NotEmpty()
               .NotNull();

        }

    }
}
