using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Korisnici;
using Backend.KlaseZaRadSaPodacima.DTObjekti.OmotaciZaValidatore.OmotaciZaZajednickeValidatore;
using Backend.KlaseZaRadSaPodacima.Enumeracije;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Zajednicki;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri.Podesavanja;
using Backend.Servisi.Enumeracije;
using FluentValidation;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Korisnici
{
    public class IDBrojValidatorSaProveromUloge : AbstractValidator<IIDBrojSaUlogom>
    {
        public IDBrojValidatorSaProveromUloge(StringValidator stringValidator,
                                              IPodesavanjaValidatoraParametaraKorisnika podesavanjaValidatoraParametaraKorisnika,
                                              IPomocnikValidiranjaZajednickimValidatorima pomocnikValidiranjaZajednickimValidatorima,
                                              IPomocnikParser pomocnikParser)
        {
            string poruka = null;
            RuleFor(idBrojSaUlogom => idBrojSaUlogom).Cascade(CascadeMode.Stop)
                                                     .Must(idBrojSaUlogom => pomocnikValidiranjaZajednickimValidatorima.validirajStringValidatorom(stringValidator,
                                                                                                                                                   Poruke.Sadrzi("IDBroj", "samo cifre [0-9]"),
                                                                                                                                                   Poruke.PotrebnoProslediti("Za osnovnog korisnika IDBroj"),
                                                                                                                                                   idBrojSaUlogom.PotrebnaValidacijaPraznihPolja,
                                                                                                                                                   idBrojSaUlogom.OcekivanaVrednostPostojanja,
                                                                                                                                                   Regex.samoBrojevi,
                                                                                                                                                   TipProverePostojanjaKorisnika.IDBroj,
                                                                                                                                                   "Korisnik",
                                                                                                                                                   podesavanjaValidatoraParametaraKorisnika,
                                                                                                                                                   new OmotacStringa(idBrojSaUlogom.IDBroj),
                                                                                                                                                   out poruka))
                                                     .WithMessage(idBrojSaUlogom => poruka)
                                                     .When(idBrojSaUlogom => (pomocnikParser.ParsiranjeUlogeIzStringa(idBrojSaUlogom.Uloga) == Uloga.Osnovni_Korisnik || idBrojSaUlogom.Uloga == null) && (idBrojSaUlogom.IDBroj != null || idBrojSaUlogom.PotrebnaValidacijaPraznihPolja))
                                                     .WithName("IDBroj");
        }
    }
}