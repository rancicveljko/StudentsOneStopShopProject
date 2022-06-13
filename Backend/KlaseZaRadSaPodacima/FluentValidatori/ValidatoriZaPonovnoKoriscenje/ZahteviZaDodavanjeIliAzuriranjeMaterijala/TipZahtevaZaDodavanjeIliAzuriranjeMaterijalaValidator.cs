using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.ZahteviZaDodavanjeIliAzuriranjeMaterijala;
using Backend.KlaseZaRadSaPodacima.DTObjekti.OmotaciZaValidatore.OmotaciZaZajednickeValidatore;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Zajednicki;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri.Podesavanja;
using FluentValidation;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.ZahteviZaDodavanjeIliAzuriranjeMaterijala
{
    public class TipZahtevaZaDodavanjeIliAzuriranjeMaterijalaValidator : AbstractValidator<ITipZahtevaZaDodavanjeIliAzuriranjeMaterijala>
    {
        public TipZahtevaZaDodavanjeIliAzuriranjeMaterijalaValidator(EnumValidator enumValidator,
                                                                     IPomocnikValidiranjaZajednickimValidatorima pomocnikValidiranjaZajednickimValidatorima,
                                                                     IPodesavanjaValidatoraParametaraZahtevaZaDodavanjeIliAzuriranjeMaterijala podesavanjaValidatoraParametaraZahtevaZaDodavanjeIliAzuriranjeMaterijala,
                                                                     IPomocnikParser pomocnikParser)
        {
            string poruka = null;
            RuleFor(tipZahteva => tipZahteva).Must(tipZahteva => pomocnikValidiranjaZajednickimValidatorima.validirajEnumValidatorom(enumValidator,
                                                                                                                                     tipZahteva.PotrebnaValidacijaPraznihPolja,
                                                                                                                                     Poruke.PotrebnoProslediti("Tip zahteva"),
                                                                                                                                     Poruke.EnumUValidnomOpsegu("Tip zahteva"),
                                                                                                                                     tipZahteva.OcekivanaVrednostPostojanja,
                                                                                                                                     TipProverePostojanjaZahtevaZaDodavanjeIliAzuriranjeMaterijala.Tip_Zahteva,
                                                                                                                                     "Zahtev za dodavanje ili ažuriranje materijala",
                                                                                                                                     podesavanjaValidatoraParametaraZahtevaZaDodavanjeIliAzuriranjeMaterijala,
                                                                                                                                     new OmotacEnumeracije(pomocnikParser.ParsiranjeTipaZahtevaZaManipulacijuMaterijalomIzStringa(tipZahteva.TipZahteva), tipZahteva.TipZahteva),
                                                                                                                                     out poruka))
                                             .WithMessage(tipZahteva => poruka)
                                             .WithName("TipZahteva");
        }
    }
}