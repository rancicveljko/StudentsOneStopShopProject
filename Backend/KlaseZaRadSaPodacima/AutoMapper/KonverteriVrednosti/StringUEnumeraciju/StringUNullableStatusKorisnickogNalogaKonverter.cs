using AutoMapper;
using Backend.KlaseZaRadSaPodacima.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.KonverteriVrednosti.StringUEnumeraciju
{
    public class StringUNullableStatusKorisnickogNalogaKonverter : ITypeConverter<string, StatusKorisnickogNaloga?>
    {
        private readonly IPomocnikParser _pomocnikParser;

        public StringUNullableStatusKorisnickogNalogaKonverter(IPomocnikParser pomocnikParser)
        {
            _pomocnikParser = pomocnikParser;
        }
        public StatusKorisnickogNaloga? Convert(string izvor, StatusKorisnickogNaloga? destinacija, ResolutionContext context)
        {
            return _pomocnikParser.ParsiranjeStatusaKorisnickogNalogaIzString(izvor);
        }
    }
}