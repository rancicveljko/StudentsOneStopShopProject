using AutoMapper;
using Backend.KlaseZaRadSaPodacima.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.KonverteriVrednosti.StringUEnumeraciju
{
    public class StringUNullableTipAdministratorskogZahtevaKonverter : ITypeConverter<string, TipAdministratorskogZahteva?>
    {
        private readonly IPomocnikParser _pomocnikparser;

        public StringUNullableTipAdministratorskogZahtevaKonverter(IPomocnikParser pomocnikParser)
        {
            _pomocnikparser = pomocnikParser;
        }

        public TipAdministratorskogZahteva? Convert(string izvor, TipAdministratorskogZahteva? destinacija, ResolutionContext context)
        {
            return _pomocnikparser.ParsiranjeTipaAdminZahtevaIzStringa(izvor);
        }
    }
}