using System.Linq;
using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Oblasti;
using Backend.KlaseZaRadSaPodacima.DTObjekti.OmotaciZaValidatore.OmotaciZaOstaleValidatore;
using Backend.KlaseZaRadSaPodacima.DTObjekti.OmotaciZaValidatore.OmotaciZaZajednickeValidatore;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Zajednicki;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri.Podesavanja;
using FluentValidation;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Oblasti
{
    public class NazivIPutanjaOblastiValidator : AbstractValidator<OmotacNazivaIPutanjeOblasti>
    {
        public NazivIPutanjaOblastiValidator(IPomocnikValidatoraPutanje pomocnikValidatoraPutanje, IPomocnikManuelniValidator pomocnikManuelniValidator, IPomocnikValidiranjaZajednickimValidatorima pomocnikValidiranjaZajednickimValidatorima, StringValidator stringValidator, PutanjaValidator putanjaValidator, IPodesavanjaValidatoraParametaraOblasti podesavanjaValidatoraParametaraOblasti)
        {
            string poruka = null;
            RuleFor(nazivIPutanja => nazivIPutanja).Cascade(CascadeMode.Stop)
                                                        
                                                        //   .Must(nazivIPutanja => pomocnikManuelniValidator.manuelnoValidiraj<IPutanja>(putanjaValidator, nazivIPutanja, out poruka))
                                                          // .WithMessage(nazivIPutanja => poruka)
                                                           .SetValidator(putanjaValidator)
                                                           .WithName("Putanja")
                                                           .DependentRules(() =>
                                                            {
                                                                RuleFor(nazivIPutanja => nazivIPutanja).Cascade(CascadeMode.Stop)
                                                                                                                .Must(nazivIPutanja => nazivIPutanja.PotrebnaValidacijaPraznihPolja ? !string.IsNullOrEmpty(nazivIPutanja.Naziv) : true)
                                                                                                                .WithMessage(nazivIPutanja => Poruke.PotrebnoProslediti("Naziv"))
                                                                                                                .Must(nazivIPutanja => string.IsNullOrEmpty(nazivIPutanja.Naziv) ? true : System.Text.RegularExpressions.Regex.IsMatch(nazivIPutanja.Naziv, Regex.slovaIBrojevi))
                                                                                                                .WithMessage(nazivIPutanja => Poruke.Sadrzi("Naziv", "samo slova i cifre"))
                                                                                                                .Must(nazivIPutanja => (!string.IsNullOrEmpty(nazivIPutanja.Naziv) && !string.IsNullOrEmpty(nazivIPutanja.Putanja) && nazivIPutanja.NazivINazivUPutanjiJednaki != null) ? ((bool)nazivIPutanja.NazivINazivUPutanjiJednaki ? nazivIPutanja.Naziv == nazivIPutanja.Putanja.Split("/").Last() : nazivIPutanja.Naziv != nazivIPutanja.Putanja.Split("/").Last()) : true)
                                                                                                                .WithMessage(nazivIPutanja => (bool)nazivIPutanja.NazivINazivUPutanjiJednaki ? Poruke.Mora("Naziv", "biti isti kao naziv u putanji") : Poruke.NeSme("Novi naziv", "biti isti kao trenutni"))
                                                                                                                .Must(nazivIPutanja => pomocnikValidiranjaZajednickimValidatorima.validirajStringValidatorom(stringValidator,
                                                                                                                                                                                                             string.IsNullOrEmpty(nazivIPutanja.Putanja) ? Poruke.NePostoji("Oblast", "navedenim nazivom") : Poruke.VecPostoji("Oblast", "navedenim nazivom u navedenoj oblasti"),
                                                                                                                                                                                                             Poruke.PotrebnoProslediti("Naziv"),
                                                                                                                                                                                                             nazivIPutanja.PotrebnaValidacijaPraznihPolja,
                                                                                                                                                                                                             nazivIPutanja.OcekivanaVrednostPostojanja,
                                                                                                                                                                                                             Regex.putanja,
                                                                                                                                                                                                             string.IsNullOrEmpty(nazivIPutanja.Putanja) ? TipProverePostojanjaOblasti.Naziv : TipProverePostojanjaOblasti.Naziv_U_Nadoblasti,
                                                                                                                                                                                                             "Oblast",
                                                                                                                                                                                                             podesavanjaValidatoraParametaraOblasti,
                                                                                                                                                                                                             string.IsNullOrEmpty(nazivIPutanja.Putanja) ? new OmotacStringa(nazivIPutanja.Naziv) : new OmotacStringa(nazivIPutanja.Putanja + "/" + nazivIPutanja.Naziv),
                                                                                                                                                                                                             out poruka))
                                                                                                                 .WithMessage(azuriranjeOblasti => poruka)
                                                                                                                 .WithName("Naziv");
                                                            });
        }
    }
}