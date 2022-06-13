using System;
using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Zajednicki;
using Backend.KlaseZaRadSaPodacima.DTObjekti.OmotaciZaValidatore.OmotaciZaZajednickeValidatore;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora;
using FluentValidation;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Zajednicki
{
    public class KriterijumSortiranjaValidator : AbstractValidator<IKriterijumSortiranja>
    {
        public KriterijumSortiranjaValidator(IPomocnikValidiranjaZajednickimValidatorima pomocnikValidiranjaZajednickimValidatorima, EnumValidator enumValidator)
        {
            string poruka = null;
            RuleFor(kriterijumSortiranja => kriterijumSortiranja).Cascade(CascadeMode.Stop)
                                                                .Must(kriterijumSortiranja => pomocnikValidiranjaZajednickimValidatorima.validirajEnumValidatorom(enumValidator,
                                                                                                                                                    false,
                                                                                                                                                    null,
                                                                                                                                                    Poruke.EnumUValidnomOpsegu("Kriterijum sortiranja"),
                                                                                                                                                    null,
                                                                                                                                                    NeProveravajPostojanje.Ne_Proveravaj_Postojanje,
                                                                                                                                                    null,
                                                                                                                                                    null,
                                                                                                                                                    new OmotacEnumeracije(ParsirajVrednostEnumeracije(kriterijumSortiranja.KriterijumSortiranja, kriterijumSortiranja.TipEnumeracije), kriterijumSortiranja.KriterijumSortiranja),
                                                                                                                                                    out poruka))
                                                                .WithMessage(kriterijumSortiranja => poruka)
                                                                .WithName("KriterijumSortiranja");
        }
        private Enum ParsirajVrednostEnumeracije(string vrednost, Type tip)
        {
            return Enum.TryParse(tip, vrednost, false, out object parsiranaVrednost) ? parsiranaVrednost as Enum : null;
        }
    }
}