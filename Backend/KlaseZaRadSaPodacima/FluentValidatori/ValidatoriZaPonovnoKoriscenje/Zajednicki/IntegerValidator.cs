using Backend.KlaseZaRadSaPodacima.DTObjekti.OmotaciZaValidatore.OmotaciZaZajednickeValidatore;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.PodesavanjaZajednickih;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora;
using FluentValidation;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Zajednicki
{
    public class IntegerValidator : AbstractValidator<OmotacIntegera>
    {
        public PodesavanjaIntegerValidatora Podesavanja { get; set; } = new PodesavanjaIntegerValidatora();
        public IntegerValidator(IPomocnikZajednickihValidatora pomocnikZajednickihValidatora,
                                IPomocnikParser pomocnikParser)
        {
            string poruka = null;
            RuleFor(omotacIntegera => omotacIntegera.UpakovanInteger).Cascade(CascadeMode.Stop)
                                                                     .Must(integer => pomocnikZajednickihValidatora.validirajPodesavanjeValidatora(Podesavanja, out poruka))
                                                                     .WithMessage(integer => poruka)
                                                                     .Must(integer => (bool)Podesavanja.PotrebnoValidiranjePrazogPolja ? string.IsNullOrEmpty(integer) : true)
                                                                     .WithMessage(integer => Podesavanja.PorukaZaPraznoPolje)
                                                                     .DependentRules(() =>
                                                                     {
                                                                         When(omotacIntegera => !string.IsNullOrEmpty(omotacIntegera.UpakovanInteger), () =>
                                                                            {
                                                                                RuleFor(omotacIntegera => pomocnikParser.ParsiranjeIntIzStringa(omotacIntegera.UpakovanInteger)).Cascade(CascadeMode.Stop)
                                                                                                                                                                                .NotNull()
                                                                                                                                                                                .WithMessage(integer => Podesavanja.PorukaZaNevalidanFormat)
                                                                                                                                                                                .LessThanOrEqualTo((int)Podesavanja.Do)
                                                                                                                                                                                .WithMessage(integer => Podesavanja.PorukaZaVeceOdDozvoljenog)
                                                                                                                                                                                .GreaterThanOrEqualTo((int)Podesavanja.Od)
                                                                                                                                                                                .WithMessage(integer => Podesavanja.PorukaZaManjeManjeOdDozvoljenog)
                                                                                                                                                                                .Must(integer => pomocnikZajednickihValidatora.validirajProveruPostojanja(Podesavanja, integer.ToString(), out poruka))
                                                                                                                                                                                .WithMessage(integer => poruka);
                                                                            });
                                                                     });
        }
    }
}