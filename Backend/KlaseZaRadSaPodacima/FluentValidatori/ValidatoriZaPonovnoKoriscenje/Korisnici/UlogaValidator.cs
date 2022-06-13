using System;
using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.DTObjekti.OmotaciZaValidatore.OmotaciZaZajednickeValidatore;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Korisnici;
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
    public class UlogaValidator : AbstractValidator<IUloga>
    {
        public UlogaValidator(IPomocnikParser pomocnikParser,
                              IPomocnikValidiranjaZajednickimValidatorima pomocnikValidiranjaZajednickimValidatorima,
                              EnumValidator enumValidator,
                              IPodesavanjaValidatoraParametaraKorisnika podesavanjaValidatoraParametaraKorisnika)
        {
            string poruka = null;
            RuleFor(uloga => uloga).Cascade(CascadeMode.Stop)
                                   .Must(uloga => pomocnikValidiranjaZajednickimValidatorima.validirajEnumValidatorom(enumValidator,
                                                                                                                      uloga.PotrebnaValidacijaPraznihPolja,
                                                                                                                      Poruke.PotrebnoProslediti("Validna uloga"),
                                                                                                                      Poruke.EnumUValidnomOpsegu("Uloga"),
                                                                                                                      uloga.OcekivanaVrednostPostojanja,
                                                                                                                      TipProverePostojanjaKorisnika.Uloga,
                                                                                                                      "Nijedan korisnik",
                                                                                                                      podesavanjaValidatoraParametaraKorisnika,
                                                                                                                      new OmotacEnumeracije(pomocnikParser.ParsiranjeUlogeIzStringa(uloga.Uloga), uloga.Uloga),
                                                                                                                      out poruka))
                                   .WithMessage(uloga => poruka)
                                   .WithName("Uloga");
        }
    }
}