using System;
using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Zajednicki;
using Backend.KlaseZaRadSaPodacima.DTObjekti.OmotaciZaValidatore.OmotaciZaZajednickeValidatore;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.PodesavanjaZajednickih;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora;
using FluentValidation;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Zajednicki
{
    public class VremeValidator : AbstractValidator<OmotacVremena>
    {
        private readonly IPomocnikParser _pomocnikParser;

        public PodesavanjaVremeValidatora Podesavanja { get; set; } = new PodesavanjaVremeValidatora();
        public VremeValidator(IPomocnikParser pomocnikParser, IPomocnikZajednickihValidatora pomocnikZajednickihValidatora)
        {
            _pomocnikParser = pomocnikParser;
            string poruka = null;

            RuleFor(omotacVremena => omotacVremena.UpakovanoVreme).Cascade(CascadeMode.Stop)
                                                                     .Must(vreme => pomocnikZajednickihValidatora.validirajPodesavanjeValidatora(Podesavanja, out poruka))
                                                                     .WithMessage(vreme => poruka)
                                                                     .Must(vreme => (bool)Podesavanja.PotrebnoValidiranjePrazogPolja ? !string.IsNullOrEmpty(vreme) : true)
                                                                     .WithMessage(vreme => Podesavanja.PorukaZaPraznoPolje)
                                                                     .Must(vreme => ValidanFormatVremena(vreme, Podesavanja, out poruka))
                                                                     .WithMessage(vreme => poruka)
                                                                     .Must(vreme => !string.IsNullOrEmpty(vreme) ? pomocnikZajednickihValidatora.validirajProveruPostojanja(Podesavanja, vreme, out poruka) : true)
                                                                     .WithMessage(vreme => poruka);
        }
        private bool ValidanFormatVremena(string vreme, PodesavanjaVremeValidatora podesavanja, out string poruka)
        {
            poruka = null;
            if (!string.IsNullOrEmpty(vreme))
            {
                var parsiranoVreme = _pomocnikParser.ParsiranjeVremenaIzStringaUniversalTime(vreme);
                if (parsiranoVreme == null)
                {
                    poruka = podesavanja.PorukaZaNevalidanFormat;
                    return false;
                }
                if ((DateTime)parsiranoVreme > (DateTime)Podesavanja.Do)
                {
                    poruka = podesavanja.PorukaZaVeceOdDozvoljenog;
                    return false;
                }
                if ((DateTime)parsiranoVreme < (DateTime)podesavanja.Od)
                {
                    poruka = podesavanja.PorukaZaManjeManjeOdDozvoljenog;
                    return false;
                }
                return true;
            }
            return true;
        }
    }
}