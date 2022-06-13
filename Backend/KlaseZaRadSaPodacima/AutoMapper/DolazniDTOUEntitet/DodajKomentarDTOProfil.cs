using AutoMapper;
using Backend.KlaseZaRadSaPodacima.AutoMapper.ResavaciVrednosti;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Materijali.Komentari;
using Backend.KlaseZaRadSaPodacima.Entiteti;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.DolazniDTOUEntitet
{
    public class DodajKomentarDTOProfil : Profile
    {
        public DodajKomentarDTOProfil()
        {

            CreateMap<DodajKomentarDTO, KomentarEntitet>().ForMember(destinacija => destinacija.Autor, map => map.MapFrom(izvor => izvor))
                                                         .ForMember(destinacija => destinacija.Materijal, map => map.MapFrom(izvor => izvor))
                                                         .ForMember(destinacija => destinacija.VremeKomentarisanja, map => map.MapFrom(izvor => izvor.VremeSlanja))
                                                         .ForMember(destinacija => destinacija.OdgovorNa, map => { map.PreCondition(izvor => !string.IsNullOrEmpty(izvor.KorisnickoImeOdgovor) && !string.IsNullOrEmpty(izvor.VremeSlanjaOdgovor)); map.MapFrom<DodajKomentarDTOUOdgovorKomentarEntitetaResavac>(); });
        }
    }
}