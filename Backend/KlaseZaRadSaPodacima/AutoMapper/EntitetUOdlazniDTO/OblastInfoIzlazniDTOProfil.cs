using System.Collections.Generic;
using AutoMapper;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Izlazni.Oblasti;
using Backend.KlaseZaRadSaPodacima.Entiteti;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.EntitetUOdlazniDTO
{
    public class OblastInfoIzlazniDTOProfil : Profile
    {
        public OblastInfoIzlazniDTOProfil()
        {
            CreateMap<OblastEntitet, OblastInfoIzlazniDTO>().ForMember(destinacija => destinacija.NaziviPodoblasti,
                                                                       map => map.MapFrom(izvor => izvor.Podoblasti))
                                                            .ForMember(destinacija => destinacija.NaziviMaterijala,
                                                                       map => map.MapFrom(izvor => izvor.Materijali));
        }
    }
}