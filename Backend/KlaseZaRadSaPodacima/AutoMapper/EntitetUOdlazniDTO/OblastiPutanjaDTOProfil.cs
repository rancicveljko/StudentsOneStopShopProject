using AutoMapper;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Izlazni.Oblasti;
using Backend.KlaseZaRadSaPodacima.Entiteti;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.EntitetUOdlazniDTO
{
    public class OblastiPutanjaDTOProfil : Profile
    {
        public OblastiPutanjaDTOProfil()
        {
            CreateMap<OblastEntitet, OblastPutanjaDTO>();
        }
    }
}