using AutoMapper;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Materijali;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Zajednicki;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Izlazni;
using Backend.KlaseZaRadSaPodacima.Entiteti;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.ProfiliZaPonovnoKoriscenje
{
    public class EntitetUIzlazniDTOProfil : Profile
    {
        public EntitetUIzlazniDTOProfil()
        {
            CreateMap<MaterijalEntitet, IPutanjaNazivIEkstenzijaMaterijalaDTO>().ForMember(destinacija => destinacija.PutanjaOblasti, map => map.MapFrom(izvor => izvor.Nadoblast.Putanja))
                                                                                .ForMember(destinacija => destinacija.NazivMaterijala, map => map.MapFrom(izvor => izvor.Naziv))
                                                                                .ForMember(destinacija => destinacija.EkstenzijaMaterijala, map => map.MapFrom(izvor => izvor.Ekstenzija));

            CreateMap<ITekstEntitet, TekstDTO>();
        }
    }
}