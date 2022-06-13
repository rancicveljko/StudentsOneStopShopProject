using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Korisnici;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.ZahteviAdministratoru;
using Backend.KlaseZaRadSaPodacima.DTObjekti.OmotaciZaValidatore.OmotaciZaOstaleValidatore;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.Korisnici;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Korisnici;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri.Podesavanja;
using FluentValidation;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.ZahteviAdministratoru
{
    public class AutorAdministratorskogZahtevaValidator : AbstractValidator<IAutorAdministratorskogZahteva>
    {
        public AutorAdministratorskogZahtevaValidator(IPomocnikManuelniValidator pomocnikManuelniValidator,
                              KorisnickoImeValidator korisnickoImeValidator,
                              IPomocnikValidatoraParametara pomocnikValidatoraParametara,
                              IPodesavanjaValidatoraParametaraAdministratorskihZahteva podesavanjaValidatoraParametaraAdministratorskihZahteva)
        {
            string poruka = null;
            RuleFor(autor => autor).Cascade(CascadeMode.Stop)
                                    .Must(autor => pomocnikManuelniValidator.manuelnoValidiraj<IKorisnickoIme>(korisnickoImeValidator,
                                                                                                              new OmotacKorisnika(autor.KorisnickoImeAutora, autor.OcekivanaVrednostPostojanja, autor.PotrebnaValidacijaPraznihPolja),
                                                                                                              out poruka))

                                    .WithMessage(autor => poruka)
                                    .DependentRules(() =>
                                    {
                                        RuleFor(autor => autor).Must(autor => pomocnikValidatoraParametara.entitetSaNavedinimParametromVecPostoji(TipProverePostojanjaAdministratorskihZahteva.Korisnicko_Ime_Autora,
                                                                                                                                                  autor.KorisnickoImeAutora,
                                                                                                                                                  podesavanjaValidatoraParametaraAdministratorskihZahteva,
                                                                                                                                                  "Administratorski zahtev",
                                                                                                                                                  autor.OcekivanaVrednostPostojanja,
                                                                                                                                                  out poruka))
                                                                .WithMessage(autor => poruka)
                                                                .When(autor => autor.PotrebnaValidacijaPraznihPolja)
                                                                .WithName("KorisnickoImeAutora");
                                    })
                                    .WithName("KorisnickoImeAutora");



        }
    }
}