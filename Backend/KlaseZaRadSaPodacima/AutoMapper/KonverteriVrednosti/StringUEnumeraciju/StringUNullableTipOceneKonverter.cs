using AutoMapper;
using Backend.KlaseZaRadSaPodacima.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.KonverteriVrednosti.StringUEnumeraciju
{
    public class StringUNullableTipOceneKonverter : ITypeConverter<string, TipOcene?>
    {
        private readonly IPomocnikParser _pomocnikParser;

        public StringUNullableTipOceneKonverter(IPomocnikParser pomocnikParser)
        {
            _pomocnikParser = pomocnikParser;
        }
        public TipOcene? Convert(string izvor, TipOcene? destinacija, ResolutionContext context)
        {
            return _pomocnikParser.ParsiranjeTipaOceneIzStringa(izvor);
        }
    }
}