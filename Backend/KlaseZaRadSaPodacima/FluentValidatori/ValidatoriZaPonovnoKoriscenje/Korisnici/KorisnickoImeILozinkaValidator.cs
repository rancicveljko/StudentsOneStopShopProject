using System.Security.Claims;
using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Korisnici;
using Backend.KlaseZaRadSaPodacima.DTObjekti.OmotaciZaValidatore.OmotaciZaZajednickeValidatore;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Zajednicki;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri.Podesavanja;
using Backend.Servisi.Enumeracije;
using FluentValidation;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Korisnici
{
    public class KorisnickoImeILozinkaValidator : AbstractValidator<IKorisnickoImeILozinka>
    {
        public KorisnickoImeILozinkaValidator(StringValidator stringValidator,
                                IPomocnikValidiranjaZajednickimValidatorima pomocnikValidiranjaZajednickimValidatorima,
                                IPodesavanjaValidatoraParametaraKorisnika podesavanjaValidatoraParametaraKorisnika,
                                KorisnickoImeValidator korisnickoImeValidator,
                                IPomocnikKolacic pomocnikKolacic)
        {
            string poruka = null;
            Include(korisnickoImeValidator);
            RuleFor(lozinka => lozinka).Must(lozinka => pomocnikValidiranjaZajednickimValidatorima.validirajStringValidatorom(stringValidator,
                                                                                                                              Poruke.Sadrzi("Lozinka ", "bar jedno veliko slovo, bar jedno malo slovo, bar jedan broj i minimalne dužine od osam karaktera!"),
                                                                                                                              Poruke.PotrebnoProslediti("Lozinku"),
                                                                                                                              true,
                                                                                                                              true,
                                                                                                                              Regex.lozinka,
                                                                                                                              TipProverePostojanjaKorisnika.Lozinka,
                                                                                                                              "",
                                                                                                                              podesavanjaValidatoraParametaraKorisnika,
                                                                                                                              new OmotacStringa($"{lozinka.Lozinka}?{(lozinka.PotrebnaValidacijaPraznihPolja ? lozinka.KorisnickoIme : pomocnikKolacic.IzvadiClaimIzKolacica(ClaimTypes.NameIdentifier))}"),
                                                                                                                              out poruka))
                                       .WithMessage(lozinka => poruka)
                                       .WithName("Lozinka");
        }
    }
}