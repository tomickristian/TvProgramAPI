using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TvProgram.Models.ViewModels;

namespace TvProgram.Validators
{
    public class DodajIliUrediZanrValidator : AbstractValidator<DodajIliUrediZanrVM>
    {
        public DodajIliUrediZanrValidator()
        {
            RuleFor(x => x.Naziv)
                .MaximumLength(20).WithMessage("Naziv mora imati do 20 slova.")
                .NotEmpty().WithMessage("Upišite naziv žanra.");
        }
    }
}
