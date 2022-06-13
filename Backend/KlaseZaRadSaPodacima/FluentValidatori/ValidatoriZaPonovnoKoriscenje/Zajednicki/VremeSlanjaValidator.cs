using System;
using System.Linq;
using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.DTObjekti.OmotaciZaValidatore.OmotaciZaZajednickeValidatore;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri.Podesavanja;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Zajednicki;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Zajednicki
{
    public class VremeSlanjaValidator : AbstractValidator<IVremeSlanja>
    {
        public VremeSlanjaValidator(IPomocnikKolacic kolacicPomocnik,
                                    IPomocnikParser pomocnikParser,
                                    VremeValidator vremeValidator,
                                    IPomocnikValidiranjaZajednickimValidatorima pomocnikValidiranjaZajednickimValidatorima,
                                    IPodesavanjaValidatoraParametaraVremenaSlanja podesavanjaValidatoraParametaraVremenaSlanja,
                                    IConfiguration konfiguracija)
        {
            var kolacicVreme = kolacicPomocnik.IzvadiClaimIzKolacica(konfiguracija["KolacicConfig:Claims:VremePrijavljivanja"]);
            string poruka = null;
            RuleFor(vremeSlanja => vremeSlanja).Cascade(CascadeMode.Stop)
                                               .Must(vremeSlanja => pomocnikValidiranjaZajednickimValidatorima.validirajVremeValidatorom(vremeValidator,
                                                                                                                                         vremeSlanja.PotrebnaValidacijaPraznihPolja,
                                                                                                                                         Poruke.PotrebnoProslediti("Vreme slanja"),
                                                                                                                                         !vremeSlanja.VremeSlanjaDodaja,
                                                                                                                                         vremeSlanja.TipProverePostojanja,
                                                                                                                                         vremeSlanja.NaizvUPorukamaPostojanjaVremeSlanja,
                                                                                                                                         podesavanjaValidatoraParametaraVremenaSlanja,
                                                                                                                                         Poruke.Mora("Vreme slanja", "mora biti manje od trenutnog vremena"),
                                                                                                                                         Poruke.PotrebnoProsleditiSaUslovom("Vreme slanja", "u validnom vremenskom formatu"),
                                                                                                                                         Poruke.Mora("Vreme slanja", "biti veće od vremena prijavljivanja"),
                                                                                                                                         new OmotacVremena(vremeSlanja.VremeSlanja),
                                                                                                                                         out poruka,
                                                                                                                                         vremeSlanja.VremeSlanjaDodaja ? pomocnikParser.ParsiranjeVremenaIzStringa(kolacicVreme) : DateTime.MinValue.ToUniversalTime(),
                                                                                                                                         DateTime.UtcNow))
                                               .WithMessage(vremeSlanja => poruka)
                                               .WithName("VremeSlanja");
        }
    }
}