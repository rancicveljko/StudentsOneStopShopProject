using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.DTObjekti.OmotaciZaValidatore.OmotaciZaZajednickeValidatore;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Materijali.Materijal;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Zajednicki;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora;
using FluentValidation;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.Materijali.Materijal
{
    public class AzuriranjeMaterijalaDTOValidator : AbstractValidator<AzuriranjeMaterijalaDTO>
    {
        public AzuriranjeMaterijalaDTOValidator(IPomocnikValidiranjaZajednickimValidatorima pomocnikValidiranjaZajednickimValidatorima, StringValidator stringValidator)
        {
            string poruka = null;
            RuleFor(azuriranjeMaterijala => azuriranjeMaterijala).Must(azuriranjeMaterijala => pomocnikValidiranjaZajednickimValidatorima.validirajStringValidatorom(stringValidator,
                                                                                                                                                                     Poruke.Mora("Ekstenzija", "biti jedna od dozvoljenih(" + Poruke.dozvoljeneEkstenzije + ")"),
                                                                                                                                                                     Poruke.PotrebnoProslediti("Tip fajla"),
                                                                                                                                                                     azuriranjeMaterijala.PotrebnaValidacijaPraznihPolja,
                                                                                                                                                                     null,
                                                                                                                                                                     Regex.tipFajla,
                                                                                                                                                                     NeProveravajPostojanje.Ne_Proveravaj_Postojanje,
                                                                                                                                                                     null,
                                                                                                                                                                     null,
                                                                                                                                                                     new OmotacStringa(azuriranjeMaterijala.NovaEkstenzija),
                                                                                                                                                                     out poruka))
                                                                 .WithMessage(azuriranjeMaterijala => poruka)
                                                                 .WithName("Tip fajla");
        }
    }
}