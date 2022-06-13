using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.DTObjekti.OmotaciZaValidatore.OmotaciZaZajednickeValidatore;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Zajednicki;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri.Podesavanja;
using FluentValidation;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Zajednicki;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Materijali
{
    public class TekstKomentaraValidator : AbstractValidator<ITekst>
    {
        public TekstKomentaraValidator(StringValidator stringValidator,
                                       IPomocnikValidiranjaZajednickimValidatorima pomocnikSetovanjaValidatora,
                                       IPodesavanjaValidatoraParametaraMaterijala podesavanjaValidatoraParametaraMaterijala)
        {
            
            RuleFor(tekst => tekst).NotEmpty();
        }
    }
}