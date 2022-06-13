using AutoMapper;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Izlazni;
using Backend.KlaseZaRadSaPodacima.Entiteti;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.EntitetUOdlazniDTO
{
    public class ZahtevAdministratoruBezTekstaDTOProfil : Profile
    {
        public ZahtevAdministratoruBezTekstaDTOProfil()
        {
            CreateMap<ZahtevAdministratoruEntitet, ZahtevAdministratoruBezTekstaDTO>().ForMember(destinacija => destinacija.KorisnickoImeAutora,
                                                                                                   map => map.MapFrom(izvor => izvor.Autor))
                                                                                      .ForMember(destinacija => destinacija.KorisnickoImeSubjekta,
                                                                                                 map => map.MapFrom(izvor => izvor.Subjekat));
        }
    }
}