using AutoMapper;
using Backend.KlaseZaRadSaPodacima.DTObjekti;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Oblasti;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.DolazniDTOUEntitet
{
    public class KreiranjeOblastiDTOProfil : Profile
    {
        public KreiranjeOblastiDTOProfil()
        {
            CreateMap<KreiranjeOblastiDTO, OblastEntitet>().ForMember(destinacija => destinacija.Nadoblast,
                                                                      map => map.MapFrom(izvor => izvor.Putanja))
                                                            .ForMember(destinacija => destinacija.Putanja,
                                                                       map => map.MapFrom(izvor => izvor.Putanja + "/" + izvor.Naziv));
        }
    }
}