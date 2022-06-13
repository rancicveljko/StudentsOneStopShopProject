using AutoMapper;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Izlazni.Korisnici;
using Backend.KlaseZaRadSaPodacima.Entiteti;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.EntitetUOdlazniDTO
{
    public class KorisnickiNalogDTOProfil : Profile
    {
        public KorisnickiNalogDTOProfil()
        {
            CreateMap<KorisnickiNalogEntitet,KorisnickiNalogDTO>();
        }
    }
}