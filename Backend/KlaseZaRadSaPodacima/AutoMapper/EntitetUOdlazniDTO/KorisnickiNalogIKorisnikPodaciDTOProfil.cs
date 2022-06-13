using AutoMapper;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Izlazni.Korisnici;
using Backend.KlaseZaRadSaPodacima.Entiteti;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.EntitetUOdlazniDTO
{
    public class KorisnickiNalogIKorisnikPodaciDTOProfil : Profile
    {
        public KorisnickiNalogIKorisnikPodaciDTOProfil()
        {
            CreateMap<KorisnickiNalogEntitet, KorisnickiNalogIKorisnikPodaciDTO>().IncludeMembers(izvor => izvor.Korisnik);
            CreateMap<KorisnikEntitet, KorisnickiNalogIKorisnikPodaciDTO>();
        }
    }
}