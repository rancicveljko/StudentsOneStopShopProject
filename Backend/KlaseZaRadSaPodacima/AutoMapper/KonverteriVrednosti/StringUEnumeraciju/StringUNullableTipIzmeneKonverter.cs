using AutoMapper;
using Backend.KlaseZaRadSaPodacima.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.KonverteriVrednosti.StringUEnumeraciju
{
    public class StringUNullableTipIzmeneKonverter : ITypeConverter<string, TipIzmene?>
    {
        private readonly IPomocnikParser _pomocnikParser;

        public StringUNullableTipIzmeneKonverter(IPomocnikParser pomocnikParser)
        {
            _pomocnikParser = pomocnikParser;
        }
        public TipIzmene? Convert(string izvor, TipIzmene? destinacija, ResolutionContext context)
        {
            return _pomocnikParser.ParsiranjeTipaIzmeneIzStringa(izvor);
        }
    }
}