using System.Linq;
using Backend.KlaseZaRadSaPodacima.DTObjekti.OmotaciZaValidatore.OmotaciZaOstaleValidatore;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Korisnici;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.ZahteviAdministratoru;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Korisnici;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri;
using FluentValidation;
using Backend.KlaseZaRadSaPodacima.DTObjekti.OmotaciZaValidatore;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri.Podesavanja;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.ZahteviAdministratoru
{
    public class AutorISubjekatAdministratorskogZahtevaValidator : AbstractValidator<IAutorISubjekatAdministratorskogZahteva>
    {

        public AutorISubjekatAdministratorskogZahtevaValidator(KorisnickoImeValidator korisnickoImeValidator,
                                       IPomocnikManuelniValidator pomocnikManuelniValidator,
                                       AutorAdministratorskogZahtevaValidator autorValidator,
                                       IPomocnikValidatoraParametara pomocnikValidatoraParametara,
                                       IPodesavanjaValidatoraParametaraAdministratorskihZahteva podesavanjaValidatoraParametaraAdministratorskihZahteva)
        {
            Include(autorValidator);
            string poruka = null;
            RuleFor(subjekat => subjekat).Cascade(CascadeMode.Stop)
                                         .Must(subjekat => pomocnikManuelniValidator.manuelnoValidiraj<IKorisnickoIme>(korisnickoImeValidator,
                                                                                                                       new OmotacKorisnika(subjekat.KorisnickoImeSubjekta, subjekat.OcekivanaVrednostPostojanja, subjekat.PotrebnaValidacijaPraznihPolja),
                                                                                                                       out poruka))

                                        .WithMessage(subjekat => poruka)
                                        .DependentRules(() =>
                                        {
                                            RuleFor(subjekat => subjekat).Must(subjekat => pomocnikValidatoraParametara.entitetSaNavedinimParametromVecPostoji(TipProverePostojanjaAdministratorskihZahteva.Korisnicko_Ime_Subjekta,
                                                                                                                                                               subjekat.KorisnickoImeSubjekta,
                                                                                                                                                               podesavanjaValidatoraParametaraAdministratorskihZahteva,
                                                                                                                                                               "Administratorski zahtev",
                                                                                                                                                               subjekat.OcekivanaVrednostPostojanja,
                                                                                                                                                               out poruka))
                                                                          .WithMessage(subjekat => poruka)
                                                                          .When(subjekat => subjekat.PotrebnaValidacijaPraznihPolja)
                                                                          .WithName("KorisnickoImeSubjekta");
                                        })
                                        .WithName("KorisnickoImeSubjekta");
        }
    }
}