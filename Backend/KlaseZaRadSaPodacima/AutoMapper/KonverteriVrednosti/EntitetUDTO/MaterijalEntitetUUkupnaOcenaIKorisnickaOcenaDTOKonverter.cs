using System.Security.Claims;
using AutoMapper;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Izlazni.Materijali;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.KonverteriVrednosti.EntitetUDTO
{
    public class MaterijalEntitetUUkupnaOcenaIKorisnickaOcenaDTOKonverter : ITypeConverter<MaterijalEntitet, UkupnaOcenaIKorisnickaOcenaDTO>
    {
        private readonly IPomocnikKolacic _pomocnikKolacic;
        private readonly IOcenaRepozitorijum _ocenaRepozitorijum;
        private readonly IKorisnickiNalogRepozitorijum _korisnickiNalogRepozitorijum;

        public MaterijalEntitetUUkupnaOcenaIKorisnickaOcenaDTOKonverter(IOcenaRepozitorijum ocenaRepozitorijum,
                                                                        IPomocnikKolacic pomocnikKolacic,
                                                                        IKorisnickiNalogRepozitorijum korisnickiNalogRepozitorijum)
        {
            _pomocnikKolacic = pomocnikKolacic;
            _ocenaRepozitorijum = ocenaRepozitorijum;
            _korisnickiNalogRepozitorijum = korisnickiNalogRepozitorijum;
        }
        public UkupnaOcenaIKorisnickaOcenaDTO Convert(MaterijalEntitet izvor, UkupnaOcenaIKorisnickaOcenaDTO destinacija, ResolutionContext context)
        {
            var korisnickoIme = _pomocnikKolacic.IzvadiClaimIzKolacica(ClaimTypes.NameIdentifier);
            var korisnickiNalog = _korisnickiNalogRepozitorijum.PribaviPoKorisnickomImenu(korisnickoIme);
            var ocenaEntitet = _ocenaRepozitorijum.PribaviSaUslovom(ocena => ocena.AutorID.Equals(korisnickiNalog.KorisnikID)
                                                                         && ocena.MaterijalID.Equals(izvor.ID));
            return destinacija = new UkupnaOcenaIKorisnickaOcenaDTO(izvor.UkupnaOcena, ocenaEntitet?.TipOcene);
        }
    }
}