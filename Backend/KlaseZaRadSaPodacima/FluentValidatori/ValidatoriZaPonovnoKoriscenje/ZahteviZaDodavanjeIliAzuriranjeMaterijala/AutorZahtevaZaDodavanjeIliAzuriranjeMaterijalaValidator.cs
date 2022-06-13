using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Korisnici;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.ZahteviZaDodavanjeIliAzuriranjeMaterijala;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Korisnici;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri.Podesavanja;
using FluentValidation;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.ZahteviZaDodavanjeIliAzuriranjeMaterijala
{
    public class AutorZahtevaZaDodavanjeIliAzuriranjeMaterijalaValidator : AbstractValidator<IAutorZahtevaZaDodavanjeIliAzuriranjeMaterijala>
    {
        public AutorZahtevaZaDodavanjeIliAzuriranjeMaterijalaValidator(KorisnickoImeValidator korisnickoImeValidator,
                                                              IPomocnikManuelniValidator pomocnikManuelniValidator,
                                                              IPomocnikValidatoraParametara pomocnikValidatoraParametara,
                                                              IPodesavanjaValidatoraParametaraZahtevaZaDodavanjeIliAzuriranjeMaterijala podesavanjaValidatoraParametaraZahtevaZaDodavanjeIliAzuriranjeMaterijala)
        {
            string poruka = null;
            RuleFor(autorZahteva => autorZahteva).Cascade(CascadeMode.Stop)
                                                 .SetValidator(korisnickoImeValidator)
                                                // .Must(autorZahteva => pomocnikManuelniValidator.manuelnoValidiraj<IKorisnickoIme>(korisnickoImeValidator, autorZahteva, out poruka))
                                                 //.WithMessage(autorZahteva => poruka)
                                                 .DependentRules(() =>
                                                 {
                                                     RuleFor(autorZahteva => autorZahteva).Must(autorZahteva => pomocnikValidatoraParametara.entitetSaNavedinimParametromVecPostoji(TipProverePostojanjaZahtevaZaDodavanjeIliAzuriranjeMaterijala.Korisnicko_Ime_Autora,
                                                                                                                                           autorZahteva.KorisnickoIme,
                                                                                                                                           podesavanjaValidatoraParametaraZahtevaZaDodavanjeIliAzuriranjeMaterijala,
                                                                                                                                           "Zahtev za dodavanje ili ažuriranje materijala",
                                                                                                                                           autorZahteva.OcekivanaVrednostPostojanja,
                                                                                                                                           out poruka))
                                                                                          .WithMessage(autorZahteva => poruka)
                                                                                          .When(autorZahteva => autorZahteva.PotrebnaValidacijaPraznihPolja)
                                                                                          .WithName("KorisnickoIme");
                                                 })
                                                 .WithName("KorisnickoIme");
        }
    }
}