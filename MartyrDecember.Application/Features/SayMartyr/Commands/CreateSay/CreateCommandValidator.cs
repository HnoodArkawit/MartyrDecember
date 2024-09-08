using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartyrDecember.Application.Features.SayMartyr.Commands.CreateSay
{
    public class CreateCommandValidator : AbstractValidator<CreateSayMartyCommand>
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
