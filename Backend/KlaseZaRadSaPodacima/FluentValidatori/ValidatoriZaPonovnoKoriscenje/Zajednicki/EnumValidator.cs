using System;
using System.Linq;
using Backend.KlaseZaRadSaPodacima.DTObjekti.OmotaciZaValidatore.OmotaciZaZajednickeValidatore;
using Backend.KlaseZaRadSaPodacima.Enumeracije;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.PodesavanjaZajednickih;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora;
using FluentValidation;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Zajednicki
{
    public class EnumValidator : AbstractValidator<OmotacEnumeracije>
    {
        public PodesavanjaEnumValidatora Podesavanja { get; set; } = new PodesavanjaEnumValidatora();
        public EnumValidator(IPomocnikZajednickihValidatora pomocnikZajednickihValidatora)
        {
            string poruka = null;
            RuleFor(omotacEnumeracije => omotacEnumeracije.StringVrednost).Cascade(CascadeMode.Stop)
                                                                             .Must(enumeracija => pomocnikZajednickihValidatora.validirajPodesavanjeValidatora(Podesavanja, out poruka))
                                                                             .WithMessage(enumeracija => poruka)
                                                                             .Must(enumeracija => (bool)Podesavanja.PotrebnoValidiranjePrazogPolja ? !string.IsNullOrEmpty(enumeracija) : true)
                                                                             .WithMessage(enumeracija => Podesavanja.PorukaZaPraznoPolje)
                                                                             .DependentRules(() =>
                                                                             {
                                                                                 When(omotacEnumeracije => !string.IsNullOrEmpty(omotacEnumeracije.StringVrednost), () =>
                                                                                    {
                                                                                        RuleFor(OmotacEnumeracije => OmotacEnumeracije.ParsiranaVrednost).Cascade(CascadeMode.Stop)
                                                                                                                                                         .NotNull()
                                                                                                                                                         .WithMessage(enumeracija => Podesavanja.PorukaZaPraznoPolje)
                                                                                                                                                         .Must(enumeracija => ProveriOpseg(enumeracija))
                                                                                                                                                         .WithMessage(enumeracija => Podesavanja.PorukaZaEnumeracijuVanOpsega)
                                                                                                                                                         .Must(enumeracija => pomocnikZajednickihValidatora.validirajProveruPostojanja(Podesavanja, enumeracija.ToString(), out poruka))
                                                                                                                                                         .WithMessage(enumeracija => poruka);
                                                                                    });
                                                                             });
        }
        private bool ProveriOpseg(Enum vrednost)
        {
            var enumNames = vrednost.GetType().GetEnumNames();
            return vrednost.ToString().Split(", ").All(vrednost => enumNames.Contains(vrednost));
        }
    }
}