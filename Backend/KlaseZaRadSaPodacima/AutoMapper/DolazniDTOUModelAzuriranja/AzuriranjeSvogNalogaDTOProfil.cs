using AutoMapper;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Korisnici;
using Backend.KlaseZaRadSaPodacima.ModeliAzuriranja;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.DolazniDTOUModelAzuriranja
{
    public class AzuriranjeSvogNalogaDTOProfil : Profile
    {
        public AzuriranjeSvogNalogaDTOProfil()
        {
            CreateMap<AzuriranjeSvogNalogaDTO, KorisnikSvojNalogAzuriranje>().ForMember(destinacija => destinacija.Lozinka,
                                                                               map => map.MapFrom(izvor => izvor.NovaLozinka));
        }
    }
}