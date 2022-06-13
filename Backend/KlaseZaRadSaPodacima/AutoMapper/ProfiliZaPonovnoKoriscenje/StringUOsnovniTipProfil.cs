using System;
using AutoMapper;
using Backend.KlaseZaRadSaPodacima.AutoMapper.KonverteriVrednosti.StringUCestiTip;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.ProfiliZaPonovnoKoriscenje
{
    public class StringUOsnovniTipProfil : Profile
    {
        public StringUOsnovniTipProfil()
        {
            CreateMap<string, DateTime>().ConvertUsing<StringUVremeKonverter>();
            CreateMap<string, DateTime?>().ConvertUsing<StringUNullableVremeKonverter>();

            CreateMap<string, int>().ConvertUsing<StringUIntKonverter>();
            CreateMap<string, int?>().ConvertUsing<StringUNullableIntKonverter>();

            CreateMap<string, bool>().ConvertUsing<StringUBoolKonverter>();
            CreateMap<string, bool?>().ConvertUsing<StringUNullableBoolKonvertor>();

            CreateMap<string,string>().ConstructUsing(izvor => string.IsNullOrEmpty(izvor) ? null : izvor);
        }
    }
}