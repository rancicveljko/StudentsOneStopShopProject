using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.DTObjekti.OmotaciZaValidatore.OmotaciZaZajednickeValidatore;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Oblasti;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Zajednicki;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri.Podesavanja;
using FluentValidation;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;
using System;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Oblasti
{
    public class PutanjaValidator : AbstractValidator<IPutanja>
    {
        public PutanjaValidator(StringValidator stringValidator,
                                IPomocnikValidiranjaZajednickimValidatorima pomocnikSetovanjaValidatora,
                                IPodesavanjaValidatoraParametaraOblasti podesavanjaValidatoraParametaraOblasti,
                                IOblastRepozitorijum oblastRepozitorijum)
        {
            string poruka = null;
            RuleFor(putanja => putanja).Cascade(CascadeMode.Stop)
                                       .Must(putanja => pomocnikSetovanjaValidatora.validirajStringValidatorom(stringValidator,
                                                                                                               Poruke.Mora("Putanja", "početi kosom crtom (/) i sadrži samo slova, cifre i kose crte, ali ne sme se završiti kosom crtom"),
                                                                                                               Poruke.PotrebnoProslediti("Putanja"),
                                                                                                               putanja.PotrebnaValidacijaPraznihPoljaPutanje,
                                                                                                               putanja.OcekivanaVrednostPostojanjaPutanje,
                                                                                                               Regex.putanja,
                                                                                                               string.IsNullOrEmpty(putanja.Putanja) ? NeProveravajPostojanje.Ne_Proveravaj_Postojanje : TipProverePostojanjaOblasti.Putanja,
                                                                                                               "Oblast",
                                                                                                               podesavanjaValidatoraParametaraOblasti,
                                                                                                               new OmotacStringa(putanja.Putanja),
                                                                                                               out poruka))
                                       .WithMessage(putanja => poruka)
                                       .WithName("Putanja");
        }
    }
}