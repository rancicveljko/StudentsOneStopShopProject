using AutoMapper;
using Backend.KlaseZaRadSaPodacima.AutoMapper.KonverteriVrednosti.DTOUEntitet;
using Backend.KlaseZaRadSaPodacima.AutoMapper.KonverteriVrednosti.StringUEntitet;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Materijali;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Materijali.Komentari;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.ZahteviZaDodavanjeIliAzuriranjeMaterijala;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Zajednicki;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Materijali.Komentari;
using Backend.KlaseZaRadSaPodacima.Entiteti;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.ProfiliZaPonovnoKoriscenje
{
    public class DTOUEntitetProfil : Profile
    {
        public DTOUEntitetProfil()
        {
            CreateMap<IPribaviZahtevZaDodavanjeIliAzuriranjeMaterijala, ZahtevZaDodavanjeIliAzuriranjeMaterijalaEntitet>().ConvertUsing<PribaviZahtevZaDodavanjeIliAzuriranjeMaterijalaUZahtevZaDodavanjeIliAzuriranjeMaterijalaEntitetKonverter>();
            CreateMap<IPutanjaNazivIEkstenzijaMaterijala, MaterijalEntitet>().ConvertUsing<PutanjaNazivIEkstenzijaMaterijalaUMaterijalEntitetKonverter>();
            CreateMap<IKorisnickiNalogIzKolacica, KorisnickiNalogEntitet>().ConvertUsing<KorisnickoImeIzKolacicaUKorisnickiNalogEntitetKonverter>();
            CreateMap<IPribaviKomentar, KomentarEntitet>().ConvertUsing<PribaviKomentarUKomentarEntitetKonverter>();
        }
    }
}