using AutoMapper;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Materijali.Komentari;
using Backend.KlaseZaRadSaPodacima.ModeliAzuriranja;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.DolazniDTOUModelAzuriranja
{
    public class AzuriranjeKomentaraDTOProfil:Profile
    {
        public AzuriranjeKomentaraDTOProfil()
        {
            CreateMap<AzuriranjeKomentaraDTO, KomentarAzuriranje>();
        }
    }
}