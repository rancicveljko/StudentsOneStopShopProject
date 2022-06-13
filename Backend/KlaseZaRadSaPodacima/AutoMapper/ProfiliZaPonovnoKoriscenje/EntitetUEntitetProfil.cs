using AutoMapper;
using Backend.KlaseZaRadSaPodacima.AutoMapper.KonverteriVrednosti.EntitetUEntitet;
using Backend.KlaseZaRadSaPodacima.AutoMapper.KonverteriVrednosti.StringUEntitet;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Zajednicki;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Materijali.Komentari;
using Backend.KlaseZaRadSaPodacima.Entiteti;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.ProfiliZaPonovnoKoriscenje
{
    public class EntitetUEntitetProfil : Profile
    {
        public EntitetUEntitetProfil()
        {
            CreateMap<ZahtevZaDodavanjeIliAzuriranjeMaterijalaEntitet, IstorijaIzmenaEntitet>().ConvertUsing<ZahtevZaDodavanjeIliAzuriranjeMaterijalaEntitetUIstorijaIzmenaEntitetKonverter>();
        }
    }
}