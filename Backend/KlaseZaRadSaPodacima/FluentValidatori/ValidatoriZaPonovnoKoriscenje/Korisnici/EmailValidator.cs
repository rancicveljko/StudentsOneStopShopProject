using System;
using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Korisnici;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Zajednicki;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri.Podesavanja;
using Backend.Servisi.Enumeracije;
using FluentValidation;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Korisnici
{
    public class EmailValidator : AbstractValidator<IEmail>
    {
        public EmailValidator(IPomocnikValidatoraParametara pomocnikValidatoraParametara, IPodesavanjaValidatoraParametaraKorisnika podesavanjaValidatoraParametaraKorisnika)
        {
            string emailPoruka = null;
            RuleFor(email => email).Cascade(CascadeMode.Stop)
                                                  .Must(email => email.PotrebnaValidacijaPraznihPolja ? !string.IsNullOrEmpty(email.Email) : true)
                                                  .WithMessage(Poruke.PotrebnoProslediti("E-mail adresa"))
                                                  .DependentRules(() =>
                                                  {
                                                      RuleFor(email => email.Email).Cascade(CascadeMode.Stop)
                                                                                   .EmailAddress()
                                                                                   .WithMessage(Poruke.NevalidanFormat("e-mail adresa", "*@*.*"))
                                                                                   .DependentRules(() =>
                                                                                   {
                                                                                       RuleFor(email => email).Must(email => string.IsNullOrEmpty(email.Email)
                                                                                                                             || pomocnikValidatoraParametara.entitetSaNavedinimParametromVecPostoji(TipProverePostojanjaKorisnika.Email,
                                                                                                                                                                                                    email.Email,
                                                                                                                                                                                                    podesavanjaValidatoraParametaraKorisnika,
                                                                                                                                                                                                    "Korisnik",
                                                                                                                                                                                                    email.OcekivanaVrednostPostojanja,
                                                                                                                                                                                                    out emailPoruka))
                                                                                                             .WithMessage(noviKorisnik => emailPoruka)
                                                                                                             .WithName("Email");
                                                                                   }).WithName("Email");
                                                  })
                                                  .WithName("Email");
        }
    }
}