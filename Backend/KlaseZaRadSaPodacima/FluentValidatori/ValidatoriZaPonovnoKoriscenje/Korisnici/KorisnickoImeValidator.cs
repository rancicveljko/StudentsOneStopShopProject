using System;
using System.Collections.Generic;
using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Korisnici;
using Backend.KlaseZaRadSaPodacima.DTObjekti.OmotaciZaValidatore.OmotaciZaZajednickeValidatore;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Zajednicki;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Implementacije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Implementacije.PomocniciValidatora.Parametri;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri.Podesavanja;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;
using Backend.Servisi.Enumeracije;
using FluentValidation;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Korisnici
{
    public class KorisnickoImeValidator : AbstractValidator<IKorisnickoIme>
    {
        public KorisnickoImeValidator(StringValidator stringValidator,
                                      IPodesavanjaValidatoraParametaraKorisnika podesavanjaValidatoraParametaraKorisnika,
                                      IPomocnikValidiranjaZajednickimValidatorima pomocnikValidiranjaZajednickimValidatorima)
        {
            string poruka = null;
            RuleFor(korisnickoIme => korisnickoIme).Cascade(CascadeMode.Stop)
                                                   .Must(korisnickoIme => pomocnikValidiranjaZajednickimValidatorima.validirajStringValidatorom(stringValidator,
                                                                                                                                                Poruke.PotrebnoProsleditiSaUslovom("Korisničko ime", "neprazno ili ga ukloniti iz zahteva"),
                                                                                                                                                Poruke.PotrebnoProslediti("Korisničko ime"),
                                                                                                                                                korisnickoIme.PotrebnaValidacijaPraznihPolja,
                                                                                                                                                korisnickoIme.OcekivanaVrednostPostojanja,
                                                                                                                                                Regex.neprazanString,
                                                                                                                                                TipProverePostojanjaKorisnika.KorisnickoIme,
                                                                                                                                                "Korisnik",
                                                                                                                                                podesavanjaValidatoraParametaraKorisnika,
                                                                                                                                                new OmotacStringa(korisnickoIme.KorisnickoIme),
                                                                                                                                                out poruka))
                                                   .WithMessage(korisnickoIme => poruka)
                                                   .WithName("KorisnickoIme");
        }
    }
}