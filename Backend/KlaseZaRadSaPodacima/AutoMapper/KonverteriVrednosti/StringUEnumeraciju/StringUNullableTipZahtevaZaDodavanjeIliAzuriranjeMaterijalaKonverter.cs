using AutoMapper;
using Backend.KlaseZaRadSaPodacima.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.KonverteriVrednosti.StringUEnumeraciju
{
    public class StringUNullableTipZahtevaZaDodavanjeIliAzuriranjeMaterijalaKonverter : ITypeConverter<string, TipZahtevaZaDodavanjeIliAzuriranjeMaterijala?>
    {
        private readonly IPomocnikParser _pomocnikParser;

        public StringUNullableTipZahtevaZaDodavanjeIliAzuriranjeMaterijalaKonverter(IPomocnikParser pomocnikParser)
        {
            _pomocnikParser = pomocnikParser;
        }
        public TipZahtevaZaDodavanjeIliAzuriranjeMaterijala? Convert(string izvor, TipZahtevaZaDodavanjeIliAzuriranjeMaterijala? destinacija, ResolutionContext context)
        {
            return _pomocnikParser.ParsiranjeTipaZahtevaZaManipulacijuMaterijalomIzStringa(izvor);
        }
    }
}