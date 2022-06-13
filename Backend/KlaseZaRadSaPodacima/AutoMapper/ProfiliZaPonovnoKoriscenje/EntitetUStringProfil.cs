using AutoMapper;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Materijali;
using Backend.KlaseZaRadSaPodacima.Entiteti;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.ProfiliZaPonovnoKoriscenje
{
    public class EntitetUStringProfil : Profile
    {
        public EntitetUStringProfil()
        {
            CreateMap<KorisnickiNalogOblastEntitet, string>().ConstructUsing(korisnickiNalogOblast => korisnickiNalogOblast.Oblast.Putanja);
            CreateMap<OblastEntitet, string>().ConvertUsing(izvor => izvor.Naziv);
            CreateMap<MaterijalEntitet, string>().ConvertUsing(izvor => izvor.Naziv);
            CreateMap<KorisnickiNalogEntitet, string>().ConvertUsing(izvor => izvor.KorisnickoIme);
            
        }
    }
}