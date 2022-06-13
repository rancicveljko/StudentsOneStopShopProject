using System;
using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.DTObjekti.OmotaciZaValidatore.OmotaciZaZajednickeValidatore;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Zajednicki;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri.Podesavanja;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Materijali.Komentari;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Materijali
{
    public class VremeKomentarisanjaValidator : AbstractValidator<IVremeKomentarisanja>
    {
        public VremeKomentarisanjaValidator(IPomocnikParser pomocnikParser,
                                            VremeValidator vremeValidator,
                                            IPomocnikValidiranjaZajednickimValidatorima pomocnikValidiranjaZajednickimValidatorima,
                                            IPodesavanjaValidatoraParametaraMaterijala podesavanjaValidatoraParametaraMaterijala,
                                            IPomocnikKolacic kolacicPomocnik,
                                            IConfiguration konfiguracija)
        {
            var kukiVreme = kolacicPomocnik.IzvadiClaimIzKolacica(konfiguracija["KolacicConfig:Claims:VremePrijavljivanja"]);
            string poruka = null;
            /*RuleFor(vremeKomentarisanja => vremeKomentarisanja).Cascade(CascadeMode.Stop)
                                                               .Must(vremeKom => pomocnikValidiranjaZajednickimValidatorima.validirajVremeValidatorom(vremeValidator,
                                                                                                                                                    vremeKom.PotrebnaValidacijaPraznihPolja,
                                                                                                                                                    Poruke.PotrebnoProslediti("Vreme komentarisanja"),
                                                                                                                                                    vremeKom.OcekivanaVrednostPostojanja,
                                                                                                                                                    TipProverePostojanjaMaterijala.Vreme_Komentarisanja,
                                                                                                                                                    "Materijal",
                                                                                                                                                    podesavanjaValidatoraParametaraMaterijala,
                                                                                                                                                    Poruke.Mora("Vreme komentarisanja", "mora biti manje od trenutnog vremena"),
                                                                                                                                                    Poruke.PotrebnoProsleditiSaUslovom("Vreme komentarisanja", "u validnom vremenskom formatu"),
                                                                                                                                                    Poruke.Mora("Vreme komentarisanja", "biti veće od vremena prijavljivanja"),
                                                                                                                                                    new OmotacVremena(vremeKom.VremeKomentarisanja),
                                                                                                                                                    out poruka,
                                                                                                                                                    vremeKom.VremeKomentarisanjaDodavanje ? pomocnikParser.ParsiranjeVremenaIzStringaUniversalTime(kukiVreme) : DateTime.MinValue.ToUniversalTime(),
                                                                                                                                                    DateTime.UtcNow))
                                                               .WithMessage(vremeKom => poruka)
                                                               .WithName("VremeKomentarisanja");*/
        }
    }
}