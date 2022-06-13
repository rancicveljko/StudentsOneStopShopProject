using AutoMapper;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.Filteri;
using Backend.KlaseZaRadSaPodacima.Filteri.ZahteviAdministratoru;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Implementacije.PomocniciValidatora;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.DolazniDTOUFilter
{
    public class PribaviSveAdministratorskeZahteveDTOProfil : Profile
    {
        public PribaviSveAdministratorskeZahteveDTOProfil()
        {
            CreateMap<PribaviSveAdministratorskeZahteveDTO, ZahtevAdministratoruFilter>().ForMember(destinacija => destinacija.Autor,
                                                                                                    map => map.MapFrom(izvor => izvor.KorisnickoImeAutora))
                                                                                         .ForMember(destinacija => destinacija.Subjekat,
                                                                                                    map => map.MapFrom(izvor => izvor.KorisnickoImeSubjekta))
                                                                                         .ForMember(destinacija => destinacija.OdVremeVremeSlanja,
                                                                                                    map => map.MapFrom(izvor => izvor.OdVreme))
                                                                                         .ForMember(destinacija => destinacija.DoVremeVremeSlanja,
                                                                                                    map => map.MapFrom(izvor => izvor.DoVreme));

        }
    }
}