using AutoMapper;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.KonverteriVrednosti.StringUCestiTip
{
    public class StringUNullableBoolKonvertor : ITypeConverter<string, bool?>
    {
        private readonly IPomocnikParser _pomocnikParser;

        public StringUNullableBoolKonvertor(IPomocnikParser pomocnikParser)
        {
            _pomocnikParser = pomocnikParser;
        }
        public bool? Convert(string izvor, bool? destinacija, ResolutionContext context)
        {
            return _pomocnikParser.ParsiranjeBoolIzStringa(izvor);
        }
    }
}