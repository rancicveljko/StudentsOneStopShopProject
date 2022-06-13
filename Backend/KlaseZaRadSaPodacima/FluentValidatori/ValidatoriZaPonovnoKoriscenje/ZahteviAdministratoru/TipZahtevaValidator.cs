using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.ZahteviAdministratoru;
using Backend.KlaseZaRadSaPodacima.DTObjekti.OmotaciZaValidatore.OmotaciZaZajednickeValidatore;
using Backend.KlaseZaRadSaPodacima.Enumeracije;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Zajednicki;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri.Podesavanja;
using FluentValidation;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.ZahteviAdministratoru
{
    public class TipZahtevaValidator : AbstractValidator<ITipZahteva>
    {
        public TipZahtevaValidator(EnumValidator enumValidator,
                                   IPomocnikValidiranjaZajednickimValidatorima pomocnikValidiranjaZajednickimValidatorima,
                                   IPodesavanjaValidatoraParametaraAdministratorskihZahteva podesavanjaValidatoraParametaraAdministratorskihZahteva,
                                   IPomocnikParser pomocnikParser)
        {
            string poruka = null;
            RuleFor(tipZahteva => tipZahteva).Cascade(CascadeMode.Stop)
                                            .Must(tipZahteva => pomocnikValidiranjaZajednickimValidatorima.validirajEnumValidatorom(enumValidator,
                                                                                                                                tipZahteva.PotrebnaValidacijaPraznihPolja,
                                                                                                                                Poruke.PotrebnoProslediti("Validan tip zahteva"),
                                                                                                                                Poruke.EnumUValidnomOpsegu("Tip zahteva"),
                                                                                                                                tipZahteva.OcekivanaVrednostPostojanja,
                                                                                                                                tipZahteva.OcekivanaVrednostPostojanja ? TipProverePostojanjaAdministratorskihZahteva.Tip_Zahteva : NeProveravajPostojanje.Ne_Proveravaj_Postojanje,
                                                                                                                                "Nijedan zahtev",
                                                                                                                                podesavanjaValidatoraParametaraAdministratorskihZahteva,
                                                                                                                                new OmotacEnumeracije(pomocnikParser.ParsiranjeTipaAdminZahtevaIzStringa(tipZahteva.Tip), tipZahteva.Tip),
                                                                                                                                out poruka))
                                            .WithMessage(tipZahteva => poruka)
                                            .Must(tipZahteva => tipZahteva.PotrebnaValidacijaPraznihPolja ? ValidirajKombinaciju((TipAdministratorskogZahteva)pomocnikParser.ParsiranjeTipaAdminZahtevaIzStringa(tipZahteva.Tip), out poruka) : true)
                                            .WithMessage(tipZahteva => poruka)
                                            
                                            .WithName("TipZahteva");
        }
        private bool ValidirajKombinaciju(TipAdministratorskogZahteva tipZahteva, out string poruka)
        {
            poruka = Poruke.Sadrzi("Tip zahteva", "jedno ili kombinaciju više ukidanja privilegja ili blokiranje ili deblokiranje naloga! Ostale kombinacije su nevalidne");

            if ((tipZahteva.HasFlag(TipAdministratorskogZahteva.Blokiranje_Korisnickog_Naloga)
                 && tipZahteva.HasFlag(TipAdministratorskogZahteva.Deblokiranje_Korisnickog_Naloga)) || ((tipZahteva.HasFlag(TipAdministratorskogZahteva.Blokiranje_Korisnickog_Naloga)
                                                                                                          || tipZahteva.HasFlag(TipAdministratorskogZahteva.Deblokiranje_Korisnickog_Naloga)) && (tipZahteva.HasFlag(TipAdministratorskogZahteva.Ukidanje_Privilegija_Komentarisanja)
                                                                                                                                                                                                                                                                                                                                                              || tipZahteva.HasFlag(TipAdministratorskogZahteva.Ukidanje_Privilegija_Ocenjivanja)
                                                                                                                                                                                                                                                                                                                                                              || tipZahteva.HasFlag(TipAdministratorskogZahteva.Ukidanje_Privilegija_Dodavanja_Materijala)))) return false;
            return true;
        }
    }
}