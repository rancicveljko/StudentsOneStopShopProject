using System.Linq;
using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Oblasti;
using Backend.KlaseZaRadSaPodacima.DTObjekti.OmotaciZaValidatore.OmotaciZaOstaleValidatore;
using Backend.KlaseZaRadSaPodacima.DTObjekti.OmotaciZaValidatore.OmotaciZaZajednickeValidatore;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Oblasti;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Oblasti;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Zajednicki;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri.Podesavanja;
using FluentValidation;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.Oblasti
{
    public class AzuriranjeOblastiDTOValidator : AbstractValidator<AzuriranjeOblastiDTO>
    {
        public AzuriranjeOblastiDTOValidator(IPomocnikValidatoraPutanje pomocnikValidatoraPutanje,
                                             IPomocnikParser pomocnikParser,
                                             IPomocnikManuelniValidator pomocnikManuelniValidator,
                                             NazivIPutanjaOblastiValidator nazivIPutanjaOblastiValidator)
        {
            string poruka = null;
            RuleFor(azuriranjeOblasti => azuriranjeOblasti).Cascade(CascadeMode.Stop)
                                                           .Must(azuriranjeOblasti => pomocnikValidatoraPutanje.DopuniPutanju(azuriranjeOblasti, false, true, out poruka))
                                                           .WithMessage(azuriranjeOblasti => Poruke.NeSme("Putanja", "biti putanja korenskog foldera"))
                                                           .Must(azuriranjeOblasti => pomocnikManuelniValidator.manuelnoValidiraj<OmotacNazivaIPutanjeOblasti>(nazivIPutanjaOblastiValidator, new OmotacNazivaIPutanjeOblasti(azuriranjeOblasti.OcekivanaVrednostPostojanjaPutanje, azuriranjeOblasti.OcekivanaVrednostPostojanja, azuriranjeOblasti.PotrebnaValidacijaPraznihPoljaPutanje, azuriranjeOblasti.PotrebnaValidacijaPraznihPolja, azuriranjeOblasti.Naziv, azuriranjeOblasti.Putanja, false), out poruka))
                                                           .WithMessage(azuriranjeOblasti => poruka)
                                                           .WithName("Putanja & Naziv");

            /*RuleFor(azuriranjeOblasti => azuriranjeOblasti).Cascade(CascadeMode.Stop)
                                                           .Must(azuriranjeOblasti => pomocnikValidatoraPutanje.DopuniPutanju(azuriranjeOblasti, false, true, out poruka))
                                                           .WithMessage(azuriranjeOblasti => poruka)
                                                           .WithName("Putanja")
                                                           .Must(azuriranjeOblasti => pomocnikManuelniValidator.manuelnoValidiraj<IPutanja>(putanjaValidator, azuriranjeOblasti, out poruka))
                                                           .WithMessage(azuriranjeOblasti => poruka)
                                                           .DependentRules(() =>
                                                            {
                                                                RuleFor(azuriranjeOblasti => azuriranjeOblasti).Cascade(CascadeMode.Stop)
                                                                                                                .Must(azuriranjeOblasti => string.IsNullOrEmpty(azuriranjeOblasti.Naziv) ? true : System.Text.RegularExpressions.Regex.IsMatch(azuriranjeOblasti.Naziv, Regex.slovaIBrojevi))
                                                                                                                .WithMessage(azuriranjeOblasti => Poruke.Sadrzi("Naziv", "samo slova i cifre"))
                                                                                                                .Must(azuriranjeOblasti => azuriranjeOblasti.Naziv != azuriranjeOblasti.Putanja.Split("/").Last())
                                                                                                                .WithMessage(azuriranjeOblasti => Poruke.NeSme("Novi naziv", "biti isti kao trenutni"))
                                                                                                                .Must(azuriranjeOblasti => pomocnikValidiranjaZajednickimValidatorima.validirajStringValidatorom(stringValidator,
                                                                                                                                                                                                                Poruke.VecPostoji("Oblast", "navedenim nazivom u navedenoj oblasti"),
                                                                                                                                                                                                                Poruke.PotrebnoProslediti("Naziv"),
                                                                                                                                                                                                                azuriranjeOblasti.PotrebnaValidacijaPraznihPolja,
                                                                                                                                                                                                                azuriranjeOblasti.OcekivanaVrednostPostojanja,
                                                                                                                                                                                                                Regex.putanja,
                                                                                                                                                                                                                TipProverePostojanjaOblasti.Putanja,
                                                                                                                                                                                                                "Oblast",
                                                                                                                                                                                                                podesavanjaValidatoraParametaraOblasti,
                                                                                                                                                                                                                string.IsNullOrEmpty(azuriranjeOblasti.Naziv) ? new OmotacStringa(azuriranjeOblasti.Naziv) : new OmotacStringa(azuriranjeOblasti.Putanja + "/" + azuriranjeOblasti.Naziv),
                                                                                                                                                                                                                out poruka))
                                                                                                                 .WithMessage(azuriranjeOblasti => poruka)
                                                                                                                 .WithName("Naziv");
                                                            });*/



            Transform(potrebnoOdobrenje => potrebnoOdobrenje.PotrebnoOdobrenje, pomocnikParser.ParsiranjeBoolIzStringa).NotNull()
                                                                                                                       .WithMessage(Poruke.PotrebnoProsleditiSaUslovom("Potrebno odobrenje", "sa validnom vrednošću (true/false)!"))
                                                                                                                       .When(potrebnoOdobrenje => potrebnoOdobrenje.PotrebnoOdobrenje != null);
        }
    }
}