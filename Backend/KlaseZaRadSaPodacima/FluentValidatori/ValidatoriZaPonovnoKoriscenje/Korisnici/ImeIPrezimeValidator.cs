using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Korisnici;
using Backend.KlaseZaRadSaPodacima.DTObjekti.OmotaciZaValidatore.OmotaciZaZajednickeValidatore;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Zajednicki;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri.Podesavanja;
using Backend.Servisi.Enumeracije;
using FluentValidation;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Korisnici
{
    public class ImeIPrezimeValidator : AbstractValidator<IImeIPrezime>
    {
        public ImeIPrezimeValidator(StringValidator stringValidator,
                                    IPomocnikValidiranjaZajednickimValidatorima pomocnikSetovanjaValidatora,
                                    IPomocnikManuelniValidator pomocnikManuelniValidator,
                                    IPodesavanjaValidatoraParametaraKorisnika podesavanjaValidatoraParametaraKorisnika)
        {
            string porukaIme = null, porukaPrezime = null;
            RuleFor(imeIPrezime => imeIPrezime).Cascade(CascadeMode.Stop)
                                               .Must(imeIPrezime => pomocnikSetovanjaValidatora.validirajStringValidatorom(stringValidator,
                                                                                                                           Poruke.Sadrzi("Ime", "samo slova"),
                                                                                                                           Poruke.PotrebnoProslediti("Ime"),
                                                                                                                           imeIPrezime.PotrebnaValidacijaPraznihPolja,
                                                                                                                           imeIPrezime.OcekivanaVrednostPostojanja,
                                                                                                                           Regex.samoMalaIVelikaSlova,
                                                                                                                           imeIPrezime.PotrebnaValidacijaPraznihPolja ? NeProveravajPostojanje.Ne_Proveravaj_Postojanje : TipProverePostojanjaKorisnika.Ime,
                                                                                                                           "Korisnik",
                                                                                                                           podesavanjaValidatoraParametaraKorisnika,
                                                                                                                           new OmotacStringa(imeIPrezime.Ime),
                                                                                                                           out porukaIme))
                                                .WithMessage(imeIPrezime => porukaIme)
                                                .WithName("Ime");

            RuleFor(imeIPrezime => imeIPrezime).Cascade(CascadeMode.Stop)
                                              .Must(imeIPrezime => pomocnikSetovanjaValidatora.validirajStringValidatorom(stringValidator,
                                                                                                                          Poruke.Sadrzi("Prezime", "samo slova"),
                                                                                                                          Poruke.PotrebnoProslediti("Prezime"),
                                                                                                                          imeIPrezime.PotrebnaValidacijaPraznihPolja,
                                                                                                                          imeIPrezime.OcekivanaVrednostPostojanja,
                                                                                                                          Regex.samoMalaIVelikaSlova,
                                                                                                                          imeIPrezime.PotrebnaValidacijaPraznihPolja ? NeProveravajPostojanje.Ne_Proveravaj_Postojanje : TipProverePostojanjaKorisnika.Prezime,
                                                                                                                          "Korisnik",
                                                                                                                          podesavanjaValidatoraParametaraKorisnika,
                                                                                                                          new OmotacStringa(imeIPrezime.Prezime),
                                                                                                                          out porukaPrezime))
                                               .WithMessage(imeIPrezime => porukaPrezime)
                                               .WithName("Prezime");
        }
    }
}