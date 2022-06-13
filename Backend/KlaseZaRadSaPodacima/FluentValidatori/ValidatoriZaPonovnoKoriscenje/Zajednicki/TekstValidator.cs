using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Zajednicki;
using FluentValidation;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Zajednicki
{
    public class TekstValidator : AbstractValidator<ITekst>
    {
        public TekstValidator()
        {
            RuleFor(tekst => tekst).Cascade(CascadeMode.Stop)
                                   .NotEmpty()
                                   .WithMessage(tekst => Poruke.PotrebnoProslediti(tekst.NazivUPorukamaPostojanjaValidatoraTeksta))
                                   .Must(tekst => tekst.Tekst.Length <= tekst.MaxDuzina)
                                   .WithMessage(tekst => Poruke.Sadrzi(tekst.NazivUPorukamaPostojanjaValidatoraTeksta, $"najviše {tekst.MaxDuzina} karaktera"))
                                   .WithName("Tekst");
        }
    }
}