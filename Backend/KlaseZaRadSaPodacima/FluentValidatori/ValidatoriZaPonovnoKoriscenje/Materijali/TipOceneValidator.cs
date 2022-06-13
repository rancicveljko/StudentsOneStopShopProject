using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.DTObjekti.OmotaciZaValidatore.OmotaciZaZajednickeValidatore;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Ocene;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Zajednicki;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri.Podesavanja;
using FluentValidation;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Materijali
{
    public class TipOceneValidator : AbstractValidator<ITipOcene>
    {
        public TipOceneValidator(IPomocnikParser pomocnikParser,
                                 IPomocnikValidiranjaZajednickimValidatorima pomocnikValidiranjaZajednickimValidatorima,
                                 EnumValidator enumValidator,
                                 IPodesavanjaValidatoraParametaraMaterijala podesavanjaValidatoraParametaraMaterijala)
        {
            string poruka = null;
            RuleFor(tipOcene => tipOcene).Cascade(CascadeMode.Stop)
                                         .Must(tipOcene => pomocnikValidiranjaZajednickimValidatorima.validirajEnumValidatorom(enumValidator,
                                                                                                                               tipOcene.PotrebnaValidacijaPraznihPolja,
                                                                                                                               Poruke.PotrebnoProslediti("Validan tip ocene"),
                                                                                                                               Poruke.EnumUValidnomOpsegu("Tip ocene"),
                                                                                                                               null,
                                                                                                                               NeProveravajPostojanje.Ne_Proveravaj_Postojanje,
                                                                                                                               "Ocena",
                                                                                                                               null,
                                                                                                                               new OmotacEnumeracije(pomocnikParser.ParsiranjeTipaOceneIzStringa(tipOcene.TipOcene), tipOcene.TipOcene),
                                                                                                                               out poruka))
                                         .WithMessage(tipOcene => poruka)
                                         .WithName("TipOcene");
        }
    }
}