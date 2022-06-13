using System;
using AutoMapper;
using Backend.KlaseZaRadSaPodacima.AutoMapper.KonverteriVrednosti.StringUEnumeraciju;
using Backend.KlaseZaRadSaPodacima.Enumeracije;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.ProfiliZaPonovnoKoriscenje
{
    public class StringUEnumeracijuProfil : Profile
    {
        public StringUEnumeracijuProfil()
        {
            CreateMap<string, Uloga>().ConvertUsing<StringUUloguKonverter>();
            CreateMap<string, Uloga?>().ConvertUsing<StringUNullableUloguKonverter>();

            CreateMap<string, StatusKorisnickogNaloga>().ConvertUsing<StringUStatusKorisnickogNalogaKonverter>();
            CreateMap<string, StatusKorisnickogNaloga?>().ConvertUsing<StringUNullableStatusKorisnickogNalogaKonverter>();

            CreateMap<string, OsnovniKorisnikPrivilegije>().ConvertUsing<StringUPrivilegijeOsnovnogKorisnikaKonverter>();
            CreateMap<string, OsnovniKorisnikPrivilegije?>().ConvertUsing<StringUNullablePrivilegijeOsnovnogKorisnikaKonverter>();

            CreateMap<string, StatusMaterijala>().ConvertUsing<StringUStatusMaterijalaKonverter>();
            CreateMap<string, StatusMaterijala?>().ConvertUsing<StringUNullableStatusMaterijalaKonverter>();

            CreateMap<string, TipAdministratorskogZahteva>().ConvertUsing<StringUTipAdministratorskogZahtevaKonverter>();
            CreateMap<string, TipAdministratorskogZahteva?>().ConvertUsing<StringUNullableTipAdministratorskogZahtevaKonverter>();

            CreateMap<string, TipIzmene>().ConvertUsing<StringUTipIzmeneKonverter>();
            CreateMap<string, TipIzmene?>().ConvertUsing<StringUNullableTipIzmeneKonverter>();

            CreateMap<string, TipOcene>().ConvertUsing<StringUTipOceneKonverter>();
            CreateMap<string, TipOcene?>().ConvertUsing<StringUNullableTipOceneKonverter>();

            CreateMap<string, TipZahtevaZaDodavanjeIliAzuriranjeMaterijala>().ConvertUsing<StringUTipZahtevaZaDodavanjeIliAzuriranjeMaterijalaKonverter>();
            CreateMap<string, TipZahtevaZaDodavanjeIliAzuriranjeMaterijala?>().ConvertUsing<StringUNullableTipZahtevaZaDodavanjeIliAzuriranjeMaterijalaKonverter>();
        }
    }
}