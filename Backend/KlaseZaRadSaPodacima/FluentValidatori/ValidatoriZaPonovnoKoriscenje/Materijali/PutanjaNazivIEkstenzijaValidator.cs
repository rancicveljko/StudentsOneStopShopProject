using System;
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
    public class PutanjaNazivIEkstenzijaValidator : AbstractValidator<IPutanjaNazivIEkstenzijaMaterijala>
    {
        public PutanjaNazivIEkstenzijaValidator(PutanjaValidator putanjaValidator,
                                                StringValidator stringValidator,
                                                IPodesavanjaValidatoraParametaraMaterijala podesavanjaValidatoraParametaraMaterijala,
                                                IPomocnikValidiranjaZajednickimValidatorima pomocnikValidiranjaZajednickimValidatorima,
                                                IPomocnikManuelniValidator pomocnikManuelniValidator,
                                                IPomocnikValidatoraPutanje pomocnikValidatoraPutanje)
        {
            string poruka = null;
            RuleFor(putanjaNazivIEkstenzija => putanjaNazivIEkstenzija).Cascade(CascadeMode.Stop)
                                                                        // .Must(putanjaNazivIEkstenzija => pomocnikValidatoraPutanje.DopuniPutanju(putanjaNazivIEkstenzija, true, false, out poruka))
                                                                        .SetValidator(putanjaValidator)
                                                                        //.Must(putanjaNazivIEkstenzija => pomocnikManuelniValidator.manuelnoValidiraj<IPutanja>(putanjaValidator, putanjaNazivIEkstenzija, out poruka))
                                                                        //.WithMessage(putanjaNazivIEkstenzija => poruka)
                                                                        .WithName("Putanja")
                                                                        .DependentRules(() =>
                                                                        {
                                                                            OmotacStringa omotac = null;
                                                                            TipProverePostojanjaMaterijala? tipProverePostojanjaMaterijala = null;
                                                                            RuleFor(putanjaNazivIEkstenzija => putanjaNazivIEkstenzija).Cascade(CascadeMode.Stop)
                                                                                                                                        .Must(putanjaNazivIEkstenzija => pomocnikValidiranjaZajednickimValidatorima.validirajStringValidatorom(stringValidator,
                                                                                                                                                                                                                                               Poruke.Sadrzi("Naziv", "samo slova i cifre"),
                                                                                                                                                                                                                                               Poruke.PotrebnoProslediti("Naziv"),
                                                                                                                                                                                                                                               putanjaNazivIEkstenzija.PotrebnaValidacijaPraznihPolja,
                                                                                                                                                                                                                                               putanjaNazivIEkstenzija.OcekivanaVrednostPostojanja,
                                                                                                                                                                                                                                               OdrediTipRegexFormataTipProverePostojanjaIFormirajOmotacStringaNaziva(putanjaNazivIEkstenzija, out tipProverePostojanjaMaterijala, out omotac),
                                                                                                                                                                                                                                               tipProverePostojanjaMaterijala,
                                                                                                                                                                                                                                               "Materijal",
                                                                                                                                                                                                                                               podesavanjaValidatoraParametaraMaterijala,
                                                                                                                                                                                                                                               omotac,
                                                                                                                                                                                                                                               out poruka))
                                                                                                                                        .WithMessage(putanjaNazivIEkstenzija => poruka)
                                                                                                                                        .WithName("Naziv")
                                                                                                                                        .DependentRules(() =>
                                                                                                                                        {
                                                                                                                                            OmotacStringa omotac = null;
                                                                                                                                            TipProverePostojanjaMaterijala? tipProverePostojanjaMaterijala = null;
                                                                                                                                            RuleFor(putanjaNazivIEkstenzija => putanjaNazivIEkstenzija).Must(putanjaNazivIEkstenzija => pomocnikValidiranjaZajednickimValidatorima.validirajStringValidatorom(stringValidator,
                                                                                                                                                                                                                                                                                                              Poruke.Mora("Ekstenzija", "biti jedna od dozvoljenih(" + Poruke.dozvoljeneEkstenzije + ")"),
                                                                                                                                                                                                                                                                                                              Poruke.PotrebnoProslediti("Ekstenzija"),
                                                                                                                                                                                                                                                                                                              putanjaNazivIEkstenzija.PotrebnaValidacijaPraznihPolja,
                                                                                                                                                                                                                                                                                                              putanjaNazivIEkstenzija.OcekivanaVrednostPostojanja,
                                                                                                                                                                                                                                                                                                              OdrediTipRegexFormataTipProverePostojanjaIFormirajOmotacStringaEkstenzije(putanjaNazivIEkstenzija, out tipProverePostojanjaMaterijala, out omotac),
                                                                                                                                                                                                                                                                                                              tipProverePostojanjaMaterijala,
                                                                                                                                                                                                                                                                                                              "Materijal",
                                                                                                                                                                                                                                                                                                              podesavanjaValidatoraParametaraMaterijala,
                                                                                                                                                                                                                                                                                                              omotac,
                                                                                                                                                                                                                                                                                                              out poruka))
                                                                                                                                                                                                           .WithMessage(PutanjaNazivIEkstenzijaValidator => poruka)
                                                                                                                                                                                                           .WithName("Ekstenzija");
                                                                                                                                        });
                                                                        });

        }
        private string OdrediTipRegexFormataTipProverePostojanjaIFormirajOmotacStringaEkstenzije(IPutanjaNazivIEkstenzijaMaterijala putanjaNazivIEkstenzija,
                                                                                                 out TipProverePostojanjaMaterijala? tipProverePostojanjaMaterijala,
                                                                                                 out OmotacStringa omotac)
        {
            if (string.IsNullOrEmpty(putanjaNazivIEkstenzija.Ekstenzija))
            {
                omotac = new OmotacStringa(putanjaNazivIEkstenzija.Ekstenzija);
                tipProverePostojanjaMaterijala = TipProverePostojanjaMaterijala.Ekstenzija;
                return Regex.tipFajla;
            }
            if (string.IsNullOrEmpty(putanjaNazivIEkstenzija.Putanja))
            {
                if (string.IsNullOrEmpty(putanjaNazivIEkstenzija.Naziv))
                {
                    omotac = new OmotacStringa(putanjaNazivIEkstenzija.Ekstenzija);
                    tipProverePostojanjaMaterijala = TipProverePostojanjaMaterijala.Ekstenzija;
                    return Regex.tipFajla;
                }
                omotac = new OmotacStringa(putanjaNazivIEkstenzija.Naziv + "#" + putanjaNazivIEkstenzija.Ekstenzija);
                tipProverePostojanjaMaterijala = TipProverePostojanjaMaterijala.Naziv_I_Ekstenzija;
                return Regex.nazivSaEkstenzijom;
            }
            if (string.IsNullOrEmpty(putanjaNazivIEkstenzija.Naziv))
            {
                omotac = new OmotacStringa(putanjaNazivIEkstenzija.Putanja + "#" + putanjaNazivIEkstenzija.Ekstenzija);
                tipProverePostojanjaMaterijala = TipProverePostojanjaMaterijala.Putanja_Nadoblasti_I_Ekstenzija;
                return Regex.putanjaIEkstenzija;
            }
            omotac = new OmotacStringa(putanjaNazivIEkstenzija.Putanja + "#" + putanjaNazivIEkstenzija.Naziv + "#" + putanjaNazivIEkstenzija.Ekstenzija);
            tipProverePostojanjaMaterijala = TipProverePostojanjaMaterijala.Naziv_Materijala_Ekstenzija_I_Putanja;
            return Regex.putanjaNazivIEkstenzija;
        }
        private string OdrediTipRegexFormataTipProverePostojanjaIFormirajOmotacStringaNaziva(IPutanjaNazivIEkstenzijaMaterijala putanjaNazivIEkstenzija,
                                                                                             out TipProverePostojanjaMaterijala? tipProverePostojanjaMaterijala,
                                                                                             out OmotacStringa omotac)
        {
            omotac = new OmotacStringa(putanjaNazivIEkstenzija.Naziv);
            tipProverePostojanjaMaterijala = TipProverePostojanjaMaterijala.Naziv_Materijala;
            if (string.IsNullOrEmpty(putanjaNazivIEkstenzija.Naziv)) return Regex.slovaIBrojevi;
            if (!string.IsNullOrEmpty(putanjaNazivIEkstenzija.Putanja))
            {
                omotac = new OmotacStringa(putanjaNazivIEkstenzija.Putanja + "#" + putanjaNazivIEkstenzija.Naziv);
                tipProverePostojanjaMaterijala = TipProverePostojanjaMaterijala.Naziv_I_Putanja_Nadoblasti;
                return Regex.putanjaINaziv;
            }
            return Regex.slovaIBrojevi;
        }
    }
}