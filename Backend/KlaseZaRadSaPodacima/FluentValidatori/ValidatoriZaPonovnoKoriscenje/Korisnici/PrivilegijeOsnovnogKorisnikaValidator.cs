using System;
using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Korisnici;
using Backend.KlaseZaRadSaPodacima.DTObjekti.OmotaciZaValidatore.OmotaciZaZajednickeValidatore;
using Backend.KlaseZaRadSaPodacima.Enumeracije;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Zajednicki;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri.Podesavanja;
using Backend.Servisi.Enumeracije;
using FluentValidation;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Korisnici
{
    public class PrivilegijeOsnovnogKorisnikaValidator : AbstractValidator<IPrivilegijeOsnovnogKorisnika>
    {
        public PrivilegijeOsnovnogKorisnikaValidator(IPomocnikValidiranjaZajednickimValidatorima pomocnikValidiranjaZajednickimValidatorima,
                                                     EnumValidator enumValidator,
                                                     IPomocnikParser pomocnikParser,
                                                     IPodesavanjaValidatoraParametaraKorisnika podesavanjaValidatoraParametaraKorisnika)
        {
            string poruka = null;
            RuleFor(privilegije => privilegije).Cascade(CascadeMode.Stop)
                                                .Must(privilegije => pomocnikValidiranjaZajednickimValidatorima.validirajEnumValidatorom(enumValidator,
                                                                                                                                          privilegije.PotrebnaValidacijaPraznihPolja,
                                                                                                                                          Poruke.PotrebnoProslediti("Validne privilegije"),
                                                                                                                                          Poruke.EnumUValidnomOpsegu("Privilegije"),
                                                                                                                                          privilegije.OcekivanaVrednostPostojanja,
                                                                                                                                          TipProverePostojanjaKorisnika.Privilegije,
                                                                                                                                          "Nijedan korisnik",
                                                                                                                                          podesavanjaValidatoraParametaraKorisnika,
                                                                                                                                          new OmotacEnumeracije(pomocnikParser.ParsiranjePrivilegijaOsnovnogKorisnikaIzStringa(privilegije.Privilegije), privilegije.Privilegije),
                                                                                                                                          out poruka))
                                                .WithMessage(privilegije => poruka)
                                                .Must(privilegije => ValidirajKombinaciju((OsnovniKorisnikPrivilegije)pomocnikParser.ParsiranjePrivilegijaOsnovnogKorisnikaIzStringa(privilegije.Privilegije), out poruka))
                                                .WithMessage(privilegije => poruka)
                                                .When(privilegije => (pomocnikParser.ParsiranjeUlogeIzStringa(privilegije.Uloga) == Uloga.Osnovni_Korisnik || privilegije.Uloga == null) && (privilegije.Privilegije != null || privilegije.PotrebnaValidacijaPraznihPolja))
                                                .WithName("Privilegije");
        }
        private bool ValidirajKombinaciju(OsnovniKorisnikPrivilegije privilegije, out string poruka)
        {
            poruka = Poruke.Sadrzi("Privilegija", "jednu ili kombinaciju više zabrana ili je bez zabrana! Ostale kombinacije su nedozvoljene!");

            if (privilegije.HasFlag(OsnovniKorisnikPrivilegije.Bez_Zabrana) &&
                                    (privilegije.HasFlag(OsnovniKorisnikPrivilegije.Zabrana_Komentarisanja)
                                     || privilegije.HasFlag(OsnovniKorisnikPrivilegije.Zabrana_Ocenjivanja)
                                     || privilegije.HasFlag(OsnovniKorisnikPrivilegije.Zabrana_Dodavanja_Materijala))) return false;
            return true;
        }
    }
}