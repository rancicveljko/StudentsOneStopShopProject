using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Materijali;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Oblasti;
using Backend.KlaseZaRadSaPodacima.DTObjekti.OmotaciZaValidatore.OmotaciZaZajednickeValidatore;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Oblasti;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Zajednicki;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri.Podesavanja;
using FluentValidation;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Materijali
{
    public class PutanjaMaterijalaValidator : AbstractValidator<IPutanjaMaterijala>
    {
        public PutanjaMaterijalaValidator(StringValidator stringValidator,
                                          PutanjaValidator putanjaValidator,
                                          IPomocnikManuelniValidator pomocnikManuelniValidator,
                                          IPomocnikValidiranjaZajednickimValidatorima pomocnikValidiranjaZajednickimValidatorima,
                                          IPodesavanjaValidatoraParametaraOblasti podesavanjaValidatoraParametaraOblasti,
                                          IPomocnikValidatoraPutanje pomocnikValidatoraPutanje)
        {
           /* string poruka = null;
            RuleFor(putanjaMaterijala => putanjaMaterijala).Cascade(CascadeMode.Stop)
                                                           .Must(putanjaMaterijala => pomocnikValidatoraPutanje.DopuniPutanju(putanjaMaterijala, true, false, out poruka))
                                                           .Must(putanjaMaterijala => pomocnikManuelniValidator.manuelnoValidiraj<IPutanja>(putanjaValidator, putanjaMaterijala, out poruka))
                                                           .WithMessage(putanjaMaterijala => poruka)
                                                           .WithName("Putanja")
                                                           .DependentRules(() =>
                                                           {
                                                               RuleFor(putanjaMaterijala => putanjaMaterijala).Must(putanjaMaterijala => pomocnikValidiranjaZajednickimValidatorima.validirajStringValidatorom(stringValidator,
                                                                                                                                                            Poruke.Sadrzi("Naziv", "slova i cifre"),
                                                                                                                                                            Poruke.PotrebnoProslediti("Naziv"),
                                                                                                                                                            putanjaMaterijala.PotrebnaValidacijaPraznihPolja,
                                                                                                                                                            true,
                                                                                                                                                            Regex.slovaIBrojevi,
                                                                                                                                                            TipProverePostojanjaMaterijala.Naziv_Materijala,
                                                                                                                                                            "Materijal",
                                                                                                                                                            podesavanjaValidatoraParametaraOblasti,
                                                                                                                                                            new OmotacStringa(putanjaMaterijala.Naziv),
                                                                                                                                                            out poruka))
                                                                                                                .WithMessage(putanjaMaterijala => poruka)
                                                                                                                .When(putanjaMaterijala => string.IsNullOrEmpty(putanjaMaterijala.Putanja) && string.IsNullOrEmpty(putanjaMaterijala.Ekstenzija))
                                                                                                                .WithName("Naziv");
                                                           });




*/
        }
       
    }
}