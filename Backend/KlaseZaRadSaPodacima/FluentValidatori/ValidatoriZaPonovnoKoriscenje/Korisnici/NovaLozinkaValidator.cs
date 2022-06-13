
using System.Linq;
using System.Security.Claims;
using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Korisnici;
using Backend.KlaseZaRadSaPodacima.DTObjekti.OmotaciZaValidatore.OmotaciZaZajednickeValidatore;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Zajednicki;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri.Podesavanja;
using Backend.Servisi.Enumeracije;
using FluentValidation;
using FluentValidation.Results;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Korisnici
{
    public class NovaLozinkaValidator : AbstractValidator<INovaLozinka>
    {
        public NovaLozinkaValidator(IPomocnikValidiranjaZajednickimValidatorima pomocnikValidiranjaZajednickimValidatorima,
                                    StringValidator stringValidator,
                                    IPodesavanjaValidatoraParametaraKorisnika podesavanjaValidatoraParametaraKorisnika,
                                    IPomocnikKolacic pomocnikKolacic)
        {
            string poruka = null;
            RuleFor(novaLozinka => novaLozinka).Must(novaLozinka => pomocnikValidiranjaZajednickimValidatorima.validirajStringValidatorom(stringValidator,
                                                                                                                                          Poruke.Sadrzi("Lozinka", "bar jedno veliko slovo, bar jedno malo slovo, bar jedan broj i minimalne dužine od osam karaktera!"),
                                                                                                                                          null,
                                                                                                                                          false,
                                                                                                                                          false,
                                                                                                                                          Regex.lozinka,
                                                                                                                                          TipProverePostojanjaKorisnika.Nova_Lozinka,
                                                                                                                                          "",
                                                                                                                                          podesavanjaValidatoraParametaraKorisnika,
                                                                                                                                          new OmotacStringa($"{novaLozinka.NovaLozinka}?{pomocnikKolacic.IzvadiClaimIzKolacica(ClaimTypes.NameIdentifier)}"),
                                                                                                                                          out poruka))
                                               .WithMessage(novaLozinka => poruka)
                                               .When(novaLozinka => !string.IsNullOrEmpty(novaLozinka.NovaLozinka))
                                               .WithName("NovaLozinka");
        }
    }
}