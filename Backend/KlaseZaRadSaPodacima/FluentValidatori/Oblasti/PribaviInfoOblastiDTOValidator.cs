using System;
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
    public class PribaviInfoOblastiDTOValidator : AbstractValidator<PribaviInfoOblastiDTO>
    {
        public PribaviInfoOblastiDTOValidator(IndeksiValidator indeksiValidator,
                                              IPomocnikParser pomocnikParser,
                                              IPomocnikValidatoraPutanje pomocnikValidatoraPutanje,
                                              IPomocnikManuelniValidator pomocnikManuelniValidator,
                                              IPomocnikValidiranjaZajednickimValidatorima pomocnikValidiranjaZajednickimValidatorima,
                                              NazivIPutanjaOblastiValidator nazivIPutanjaOblastiValidator,
                                              KriterijumSortiranjaValidator kriterijumSortiranjaValidator)
        {
            Include(kriterijumSortiranjaValidator);
            Include(indeksiValidator);
            string poruka = null;
            RuleFor(oblastZaPribavljanje => oblastZaPribavljanje).Cascade(CascadeMode.Stop)
                                                                 .Must(oblastZaPribavljanje => pomocnikValidatoraPutanje.DopuniPutanju(oblastZaPribavljanje, false, false, out poruka))
                                                                 .Must(oblastZaPribavljanje => pomocnikManuelniValidator.manuelnoValidiraj<OmotacNazivaIPutanjeOblasti>(nazivIPutanjaOblastiValidator, new OmotacNazivaIPutanjeOblasti(oblastZaPribavljanje.OcekivanaVrednostPostojanjaPutanje, oblastZaPribavljanje.OcekivanaVrednostPostojanja, oblastZaPribavljanje.PotrebnaValidacijaPraznihPoljaPutanje, oblastZaPribavljanje.PotrebnaValidacijaPraznihPolja, oblastZaPribavljanje.Naziv, oblastZaPribavljanje.Putanja, true), out poruka))
                                                                 .WithMessage(oblastZaPribavljanje => poruka)
                                                                 .WithName("Putanja & Naziv");

            /* RuleFor(oblastiZaPribavljanje => oblastiZaPribavljanje).Cascade(CascadeMode.Stop)
                                                                 .Must(oblastiZaPribavljanje => pomocnikValidatoraPutanje.DopuniPutanju(oblastiZaPribavljanje, false, false, out poruka))
                                                                 .WithMessage(oblastiZaPribavljanje => poruka)
                                                                 .Must(oblastiZaPribavljanje => pomocnikManuelniValidator.manuelnoValidiraj<IPutanja>(putanjaValidator, oblastiZaPribavljanje, out poruka))
                                                                 .WithMessage(oblastiZaPribavljanje => poruka)
                                                                 .WithName("Putanja")
                                                                 .DependentRules(() =>
                                                                     {
                                                                         RuleFor(oblastiZaPribavljanje => oblastiZaPribavljanje).Cascade(CascadeMode.Stop)
                                                                                                                         .Must(oblastiZaPribavljanje => string.IsNullOrEmpty(oblastiZaPribavljanje.Naziv) ? true : System.Text.RegularExpressions.Regex.IsMatch(oblastiZaPribavljanje.Naziv, Regex.slovaIBrojevi))
                                                                                                                         .WithMessage(oblastiZaPribavljanje => Poruke.Sadrzi("Naziv", "samo slova i cifre"))
                                                                                                                         .Must(oblastiZaPribavljanje => (string.IsNullOrEmpty(oblastiZaPribavljanje.Putanja) || string.IsNullOrEmpty(oblastiZaPribavljanje.Naziv)) ? true : oblastiZaPribavljanje.Naziv == oblastiZaPribavljanje.Putanja.Split("/").Last())
                                                                                                                         .WithMessage(oblastiZaPribavljanje => Poruke.Mora("Naziv", "biti isti kao naziv u putanji"))
                                                                                                                         .Must(oblastiZaPribavljanje => pomocnikValidiranjaZajednickimValidatorima.validirajStringValidatorom(stringValidator,
                                                                                                                                                                                                                         Poruke.NePostoji("Oblast", "navedenim nazivom u navedenoj oblasti"),
                                                                                                                                                                                                                         Poruke.PotrebnoProslediti("Naziv"),
                                                                                                                                                                                                                         false,
                                                                                                                                                                                                                         true,
                                                                                                                                                                                                                         string.IsNullOrEmpty(oblastiZaPribavljanje.Putanja) ? Regex.sveDozvoljeno : Regex.putanja,
                                                                                                                                                                                                                         string.IsNullOrEmpty(oblastiZaPribavljanje.Putanja) ? TipProverePostojanjaOblasti.Naziv : TipProverePostojanjaOblasti.Putanja,
                                                                                                                                                                                                                         "Oblast",
                                                                                                                                                                                                                         podesavanjaValidatoraParametaraOblasti,
                                                                                                                                                                                                                         string.IsNullOrEmpty(oblastiZaPribavljanje.Putanja) ? new OmotacStringa(oblastiZaPribavljanje.Naziv) : new OmotacStringa(oblastiZaPribavljanje.Putanja),
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