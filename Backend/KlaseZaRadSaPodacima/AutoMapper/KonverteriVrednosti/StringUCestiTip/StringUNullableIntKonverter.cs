using AutoMapper;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.KonverteriVrednosti.StringUCestiTip
{
    public class StringUNullableIntKonverter : ITypeConverter<string, int?>
    {
        private readonly IPomocnikParser _pomocnikParser;

        public StringUNullableIntKonverter(IPomocnikParser pomocnikParser)
        {
            _pomocnikParser = pomocnikParser;
        }
        public int? Convert(string izvor, int? destinacija, ResolutionContext context)
        {
            return _pomocnikParser.ParsiranjeIntIzStringa(izvor);
        }
    }
}