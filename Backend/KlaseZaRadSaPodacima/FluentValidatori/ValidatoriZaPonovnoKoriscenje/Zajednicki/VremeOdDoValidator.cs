using System;
using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.DTObjekti.OmotaciZaValidatore.OmotaciZaZajednickeValidatore;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Zajednicki;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri.Podesavanja;
using FluentValidation;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Zajednicki
{
    public class VremeOdDoValidator : AbstractValidator<IVremeOdDo>
    {
        private readonly IServiceProvider _serviceProvider;

        public VremeOdDoValidator(VremeValidator vremeValidator,
                                  IPomocnikManuelniValidator pomocnikManuelniValidator,
                                  IPomocnikValidiranjaZajednickimValidatorima pomocnikValidiranjaZajednickimValidatorima,
                                  IPomocnikParser pomocnikParser,
                                  IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            string porukaVremenaOd = null, porukaVremenaDo = null;
            RuleFor(VremeOdDo => VremeOdDo).Cascade(CascadeMode.Stop)
                                           .Must(vremeOdDo => pomocnikValidiranjaZajednickimValidatorima.validirajVremeValidatorom(vremeValidator,
                                                                                                                                   false,
                                                                                                                                   "",
                                                                                                                                   true,
                                                                                                                                   TipProverePostojanjaVremenaOdDo.Od_Vremena,
                                                                                                                                   vremeOdDo.NazivUPorukamaPostojanjaVremeOdDo,
                                                                                                                                   pribaviPodesavanje(vremeOdDo.PodesavanjaValidatoraParametaraVremeOdDo),
                                                                                                                                   Poruke.Mora("Vreme od", "biti manje od vremena do"),
                                                                                                                                   Poruke.PotrebnoProsleditiSaUslovom("Vreme od", "u validnom vremenskom formatu"),
                                                                                                                                   Poruke.Mora("Vreme od", "biti veće od: " + DateTime.MinValue.ToString()),
                                                                                                                                   new OmotacVremena(vremeOdDo.OdVreme),
                                                                                                                                   out porukaVremenaOd,
                                                                                                                                   null,
                                                                                                                                   pomocnikParser.ParsiranjeVremenaIzStringaUniversalTime(vremeOdDo.DoVreme)))
                                            .WithMessage(vremeOdDo => porukaVremenaOd)
                                            .WithName("OdVreme");

            RuleFor(VremeOdDo => VremeOdDo).Cascade(CascadeMode.Stop)
                                           .Must(vremeOdDo => pomocnikValidiranjaZajednickimValidatorima.validirajVremeValidatorom(vremeValidator,
                                                                                                                                   false,
                                                                                                                                   "",
                                                                                                                                   true,
                                                                                                                                   TipProverePostojanjaVremenaOdDo.Do_Vremena,
                                                                                                                                   vremeOdDo.NazivUPorukamaPostojanjaVremeOdDo,
                                                                                                                                   pribaviPodesavanje(vremeOdDo.PodesavanjaValidatoraParametaraVremeOdDo),
                                                                                                                                   Poruke.Mora("Vreme do", "biti manje trenutnog vremena"),
                                                                                                                                   Poruke.PotrebnoProsleditiSaUslovom("Vreme do", "u validnom vremenskom formatu"),
                                                                                                                                   Poruke.Mora("Vreme do", "biti veće od vremena od"),
                                                                                                                                   new OmotacVremena(vremeOdDo.DoVreme),
                                                                                                                                   out porukaVremenaDo,
                                                                                                                                   pomocnikParser.ParsiranjeVremenaIzStringaUniversalTime(vremeOdDo.OdVreme),
                                                                                                                                   DateTime.UtcNow))
                                            .WithMessage(vremeOdDo => porukaVremenaDo)
                                            .WithName("DoVreme");
        }

        private IPodesavanjaValidatoraParametara pribaviPodesavanje(Type tipPodesavanja)
        {
            var podesavanje = _serviceProvider.GetService(tipPodesavanja);
            if (podesavanje.GetType().IsAssignableTo(typeof(IPodesavanjaValidatoraParametara))) return (IPodesavanjaValidatoraParametara)podesavanje;
            return null;
        }
    }
}