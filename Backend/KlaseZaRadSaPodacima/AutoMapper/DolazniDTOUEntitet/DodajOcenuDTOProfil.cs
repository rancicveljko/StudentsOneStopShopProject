using AutoMapper;
using Backend.KlaseZaRadSaPodacima.AutoMapper.KonverteriVrednosti.DTOUEntitet;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Materijali.Ocene;
using Backend.KlaseZaRadSaPodacima.Entiteti;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.DolazniDTOUEntitet
{
    public class DodajOcenuDTOProfil : Profile
    {
        public DodajOcenuDTOProfil()
        {
            CreateMap<DodajOcenuDTO, OcenaEntitet>().ConvertUsing<DodajOcenuDTOUOcenaEntitetKonverter>();
        }
    }
}