using AutoMapper;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Izlazni.Materijali;
using Backend.KlaseZaRadSaPodacima.Entiteti;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.EntitetUOdlazniDTO
{
    public class KomentarIzlazniDTOProfil : Profile
    {
        public KomentarIzlazniDTOProfil()
        {
            CreateMap<KomentarEntitet, KomentarIzlazniDTO>().ForMember(destinacija => destinacija.KorisnickoIme,
                                                                       map => map.MapFrom(izvor => izvor.Autor))
                                                            .ForMember(destinacija => destinacija.UlogaAutora,
                                                                       map => map.MapFrom(izvor => izvor.Autor.Uloga));
        }
    }
}