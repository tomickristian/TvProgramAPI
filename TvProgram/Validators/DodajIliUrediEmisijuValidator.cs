using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TvProgram.Models.ViewModels;

namespace TvProgram.Validators
{
    public class DodajIliUrediEmisijuValidator : AbstractValidator<DodajIliUrediEmisijuVM>
    {
        public DodajIliUrediEmisijuValidator()
        {
            RuleFor(x => x.Naziv)
                .MaximumLength(50).WithMessage("Naziv mora imati do 50 slova.")
                .NotEmpty().WithMessage("Upišite naziv emisije.");
            RuleFor(x => x.Opis)
                .MaximumLength(200).WithMessage("Opis mora imati do 200 slova.")
                .NotEmpty().WithMessage("Upišite opis emisije.");
            RuleFor(x => x.TvPostajaId)
                .NotEmpty().WithMessage("Izaberite tv-postaju.");
            RuleFor(x => x.ZanrId)
                .NotEmpty().WithMessage("Izaberite žanr.");
        }
    }
}
