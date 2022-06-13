using System;
using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.DTObjekti.OmotaciZaValidatore.OmotaciZaZajednickeValidatore;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.PodesavanjaZajednickih;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri;
using Backend.Servisi.Enumeracije;
using FluentValidation;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Zajednicki
{
    public class StringValidator : AbstractValidator<OmotacStringa>
    {
        public PodesavanjaStringValidatora Podesavanja { get; set; } = new PodesavanjaStringValidatora();
        public StringValidator(IPomocnikZajednickihValidatora pomocnikZajednickihValidatora)
        {
            string poruka = null;
            RuleFor(omotacStringa => omotacStringa.UpakovanString).Cascade(CascadeMode.Stop)
                                                                  .Must(upakovanString => pomocnikZajednickihValidatora.validirajPodesavanjeValidatora(Podesavanja, out poruka))
                                                                  .WithMessage(upakovanString => poruka)
                                                                  .Must(upakovanString => (bool)Podesavanja.PotrebnoValidiranjePrazogPolja ? !string.IsNullOrEmpty(upakovanString) : true)
                                                                  .WithMessage(upakovanString => Podesavanja.PorukaZaPraznoPolje)
                                                                  .Matches(upakovanString => !string.IsNullOrEmpty(upakovanString.UpakovanString) ? Podesavanja.RegexFormata : Regex.sveDozvoljeno)
                                                                  .WithMessage(upakovanString => Podesavanja.PorukaZaNevalidanFormat)
                                                                  .Must(upakovanString => !string.IsNullOrEmpty(upakovanString) ? pomocnikZajednickihValidatora.validirajProveruPostojanja(Podesavanja, upakovanString, out poruka) : true)
                                                                  .WithMessage(upakovanString => poruka);
        }

    }

}