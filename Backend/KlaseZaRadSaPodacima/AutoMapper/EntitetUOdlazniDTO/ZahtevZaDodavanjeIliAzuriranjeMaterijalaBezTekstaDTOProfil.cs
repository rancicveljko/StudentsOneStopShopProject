using AutoMapper;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Materijali;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Izlazni.ZahteviZaDodavanjeIliAzuriranjeMaterijala;
using Backend.KlaseZaRadSaPodacima.Entiteti;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.EntitetUOdlazniDTO
{
    public class ZahtevZaDodavanjeIliAzuriranjeMaterijalaBezTekstaDTOProfil : Profile
    {
        public ZahtevZaDodavanjeIliAzuriranjeMaterijalaBezTekstaDTOProfil()
        {
            CreateMap<MaterijalEntitet, ZahtevZaDodavanjeIliAzuriranjeMaterijalaBezTekstaDTO>().IncludeBase<MaterijalEntitet, IPutanjaNazivIEkstenzijaMaterijalaDTO>();
            CreateMap<ZahtevZaDodavanjeIliAzuriranjeMaterijalaEntitet, ZahtevZaDodavanjeIliAzuriranjeMaterijalaBezTekstaDTO>().IncludeMembers(izvor => izvor.Materijal)
                                                                                                                              .ForMember(destinacija => destinacija.KorisnickoImeAutora, map => map.MapFrom(izvor => izvor.Autor));
        }
    }
}