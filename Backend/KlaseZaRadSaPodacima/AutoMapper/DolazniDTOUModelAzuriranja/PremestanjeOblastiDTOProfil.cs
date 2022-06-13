using AutoMapper;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Oblasti;
using Backend.KlaseZaRadSaPodacima.ModeliAzuriranja;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.DolazniDTOUModelAzuriranja
{
    public class PremestanjeOblastiDTOProfil : Profile
    {
        public PremestanjeOblastiDTOProfil()
        {
            CreateMap<PremestanjeOblastiDTO, PremestanjeOblastiAzuriranje>().ForMember(destinacija => destinacija.Nadoblast,
                                                                                       map => map.MapFrom(izvor => izvor.PutanjaNoveNadoblasti));
        }
    }
}