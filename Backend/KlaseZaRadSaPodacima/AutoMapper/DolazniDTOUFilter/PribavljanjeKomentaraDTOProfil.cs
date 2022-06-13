using AutoMapper;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Materijali.Komentari;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.Filteri.Materijali;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.DolazniDTOUFilter
{
    public class PribavljanjeKomentaraDTOProfil : Profile
    {
        public PribavljanjeKomentaraDTOProfil()
        {
            CreateMap<PribavljanjeKomentaraDTO, KomentarEntitet>().ForPath(destinacija => destinacija.Autor, map => map.MapFrom(izvor => izvor.KorisnickoImeOdgovor))
                                                                  .ForMember(destinacija => destinacija.VremeKomentarisanja, map => map.MapFrom(izvor => izvor.VremeSlanjaOdgovor))
                                                                  .AfterMap((izvor, destinacija) => destinacija.AutorID = destinacija.Autor.KorisnikID);

            CreateMap<PribavljanjeKomentaraDTO, KomentariFilter>().ForMember(destinacija => destinacija.Materijal, map => map.MapFrom(izvor => izvor))
                                                                  .ForMember(destinacija => destinacija.Autor, map => map.MapFrom(izvor => izvor.KorisnickoIme))
                                                                  .ForMember(destinacija => destinacija.DoVremeVremeKomentarisanja, map => map.MapFrom(izvor => izvor.DoVreme))
                                                                  .ForMember(destinacija => destinacija.OdVremeVremeKomentarisanja, map => map.MapFrom(izvor => izvor.OdVreme))
                                                                  .ForMember(destinacija => destinacija.NullOdgovorNa, map => { map.PreCondition(izvor => !string.IsNullOrEmpty(izvor.VremeSlanjaOdgovor) && !string.IsNullOrEmpty(izvor.KorisnickoImeOdgovor)); map.MapFrom(izvor => izvor); })
                                                                  .AfterMap((izvor, destinacija) => { if (destinacija.NullOdgovorNa != null) destinacija.NullOdgovorNa.MaterijalID = destinacija.Materijal.ID; });
        }
    }
}