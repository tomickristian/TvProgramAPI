using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TvProgram.Models.ViewModels;

namespace TvProgram.Validators
{
    public class DodajIliUrediTvPostajuValidator : AbstractValidator<DodajIliUrediTvPostajuVM>
    {
        public DodajIliUrediTvPostajuValidator()
        {
            RuleFor(x => x.Naziv)
                .MaximumLength(20).WithMessage("Naziv mora imati do 20 slova.")
                .NotEmpty().WithMessage("Upišite naziv tv-postaje.");
        }
    }
}
