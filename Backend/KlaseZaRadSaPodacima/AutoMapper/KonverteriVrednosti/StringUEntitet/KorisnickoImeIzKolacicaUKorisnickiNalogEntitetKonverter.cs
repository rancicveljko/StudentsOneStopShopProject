using System.Security.Claims;
using AutoMapper;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Zajednicki;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.KonverteriVrednosti.StringUEntitet
{
    public class KorisnickoImeIzKolacicaUKorisnickiNalogEntitetKonverter : ITypeConverter<IKorisnickiNalogIzKolacica, KorisnickiNalogEntitet>
    {
        private readonly IPomocnikKolacic _pomocnikKolacic;
        private readonly IKorisnickiNalogRepozitorijum _korisnickiNalogRepozitorijum;

        public KorisnickoImeIzKolacicaUKorisnickiNalogEntitetKonverter(IPomocnikKolacic pomocnikKolacic, IKorisnickiNalogRepozitorijum korisnickiNalogRepozitorijum)
        {
            _pomocnikKolacic = pomocnikKolacic;
            _korisnickiNalogRepozitorijum = korisnickiNalogRepozitorijum;
        }

        public KorisnickiNalogEntitet Convert(IKorisnickiNalogIzKolacica source, KorisnickiNalogEntitet destination, ResolutionContext context)
        {
            return _korisnickiNalogRepozitorijum.PribaviPoKorisnickomImenu(_pomocnikKolacic.IzvadiClaimIzKolacica(ClaimTypes.NameIdentifier));
        }
    }
}