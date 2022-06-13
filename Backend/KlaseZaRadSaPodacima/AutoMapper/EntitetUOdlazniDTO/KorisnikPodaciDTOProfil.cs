using AutoMapper;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Izlazni.Korisnici;
using Backend.KlaseZaRadSaPodacima.Entiteti;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.EntitetUOdlazniDTO
{
    public class KorisnikPodaciDTOProfil : Profile
    {
        public KorisnikPodaciDTOProfil()
        {
            CreateMap<OsnovniKorisnikPodaciEntitet, KorisnikPodaciDTO>();
            CreateMap<KorisnikEntitet, KorisnikPodaciDTO>().IncludeMembers(izvor => izvor.OsnovniKorisnikPodaci);
            CreateMap<KorisnickiNalogEntitet,KorisnikPodaciDTO>().IncludeMembers(izvor => izvor.Korisnik);
        }
    }
}