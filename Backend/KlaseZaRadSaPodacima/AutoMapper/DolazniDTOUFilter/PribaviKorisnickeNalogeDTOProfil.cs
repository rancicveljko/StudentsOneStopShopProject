using AutoMapper;
using Backend.KlaseZaRadSaPodacima.AutoMapper.ResavaciVrednosti;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Korisnici;
using Backend.KlaseZaRadSaPodacima.Filteri.Korisnici;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.DolazniDTOUFilter
{
    public class PribaviKorisnickeNalogeDTOProfil : Profile
    {
        public PribaviKorisnickeNalogeDTOProfil()
        {
            CreateMap<PribaviKorisnickeNalogeDTO, KorisnickiNalogFilter>().ForMember(destinacija => destinacija.SadrziNadlezanZaOblasti, map => { map.PreCondition(pribaviKorisnickeNalogeDTO => pribaviKorisnickeNalogeDTO.Putanja != null); map.MapFrom<StringPutanjaUListuNadleznosti>(); });


        }
    }
}