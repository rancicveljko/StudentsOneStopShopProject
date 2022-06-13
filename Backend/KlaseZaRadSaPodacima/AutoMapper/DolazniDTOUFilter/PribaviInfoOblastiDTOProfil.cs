using AutoMapper;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Oblasti;
using Backend.KlaseZaRadSaPodacima.Filteri.Oblasti;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.DolazniDTOUFilter
{
    public class PribaviInfoOblastiDTOProfil : Profile
    {
        public PribaviInfoOblastiDTOProfil()
        {
            CreateMap<PribaviInfoOblastiDTO, OblastInfoFilter>();
        }
    }
}