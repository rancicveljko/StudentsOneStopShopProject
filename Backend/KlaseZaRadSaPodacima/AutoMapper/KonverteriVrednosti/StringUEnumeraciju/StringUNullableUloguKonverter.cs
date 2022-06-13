using AutoMapper;
using Backend.KlaseZaRadSaPodacima.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.KonverteriVrednosti.StringUEnumeraciju
{
    public class StringUNullableUloguKonverter : ITypeConverter<string, Uloga?>
    {
        private readonly IPomocnikParser _pomocnikParser;

        public StringUNullableUloguKonverter(IPomocnikParser pomocnikParser)
        {
            _pomocnikParser = pomocnikParser;
        }
        public Uloga? Convert(string izvor, Uloga? destinacija, ResolutionContext context)
        {
            return _pomocnikParser.ParsiranjeUlogeIzStringa(izvor);
        }
    }
}