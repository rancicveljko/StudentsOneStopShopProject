using AutoMapper;
using Backend.KlaseZaRadSaPodacima.AutoMapper.KonverteriVrednosti.StringUEntitet;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Zajednicki;
using Backend.KlaseZaRadSaPodacima.Entiteti;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.ProfiliZaPonovnoKoriscenje
{
    public class StringUEntitetProfil : Profile
    {
        public StringUEntitetProfil()
        {
            CreateMap<string, KorisnickiNalogEntitet>().ConvertUsing<StringKorisnickoImeUKorisnickiNalogEntitetKonverter>();
            CreateMap<string, OblastEntitet>().ConvertUsing<StringPutanjaUOblastEntitetKonverter>();
        }
    }
}