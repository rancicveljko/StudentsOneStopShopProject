using AutoMapper;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Oblasti;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.ModeliAzuriranja;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.DolazniDTOUModelAzuriranja
{
    public class AzuriranjeOblastiDTOProfil : Profile
    {
        public AzuriranjeOblastiDTOProfil()
        {
            CreateMap<AzuriranjeOblastiDTO, OblastAzuriranje>();
        }
    }
}