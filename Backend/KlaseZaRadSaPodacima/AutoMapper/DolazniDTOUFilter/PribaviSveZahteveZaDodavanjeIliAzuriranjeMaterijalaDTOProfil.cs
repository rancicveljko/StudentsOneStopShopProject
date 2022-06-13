using AutoMapper;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.ZahteviZaDodavanjeIliAzuriranjeMaterijala;
using Backend.KlaseZaRadSaPodacima.Filteri.ZahteviZaDodavanjeIliAzuriranjeMaterijala;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.DolazniDTOUFilter
{
    public class PribaviSveZahteveZaDodavanjeIliAzuriranjeMaterijalaDTOProfil : Profile
    {
        public PribaviSveZahteveZaDodavanjeIliAzuriranjeMaterijalaDTOProfil()
        {
            CreateMap<PribaviSveZahteveZaDodavanjeIliAzuriranjeMaterijalaDTO, ZahtevZaDodavanjeIliAzuriranjeMaterijalaFilter>().ForMember(destinacija => destinacija.OdVremeVremeSlanja,
                                                                                                                                          map => map.MapFrom(izvor => izvor.OdVreme))
                                                                                                                               .ForMember(destinacija => destinacija.DoVremeVremeSlanja,
                                                                                                                                          map => map.MapFrom(izvor => izvor.DoVreme));
        }
    }
}