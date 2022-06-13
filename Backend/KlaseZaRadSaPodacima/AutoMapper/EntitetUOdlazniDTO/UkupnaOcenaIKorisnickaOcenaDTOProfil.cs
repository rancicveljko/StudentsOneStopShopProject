using AutoMapper;
using Backend.KlaseZaRadSaPodacima.AutoMapper.KonverteriVrednosti.EntitetUDTO;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Izlazni.Materijali;
using Backend.KlaseZaRadSaPodacima.Entiteti;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.EntitetUOdlazniDTO
{
    public class UkupnaOcenaIKorisnickaOcenaDTOProfil : Profile
    {
        public UkupnaOcenaIKorisnickaOcenaDTOProfil()
        {
            CreateMap<MaterijalEntitet, UkupnaOcenaIKorisnickaOcenaDTO>().ConvertUsing<MaterijalEntitetUUkupnaOcenaIKorisnickaOcenaDTOKonverter>();
        }
    }
}