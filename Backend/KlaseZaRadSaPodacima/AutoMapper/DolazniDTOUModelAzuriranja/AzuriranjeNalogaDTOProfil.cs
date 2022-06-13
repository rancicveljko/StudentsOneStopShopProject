using AutoMapper;
using Backend.KlaseZaRadSaPodacima.AutoMapper.ResavaciVrednosti;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Korisnici;
using Backend.KlaseZaRadSaPodacima.ModeliAzuriranja;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.DolazniDTOUModelAzuriranja
{
    public class AzuriranjeNalogaDTOProfil : Profile
    {
        public AzuriranjeNalogaDTOProfil()
        {
            CreateMap<AzuriranjeNalogaDTO, KorisnikAzuriranje>()
                                                                .ForMember(destinacija => destinacija.NadlezanZaOblasti, map => { map.PreCondition(izvor => izvor.PutanjeOblasti != null); map.MapFrom<ListaStringPutanjaUListuNadleznostiResavac>(); });
        }
    }
}