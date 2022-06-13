using AutoMapper;
using Backend.KlaseZaRadSaPodacima.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.KonverteriVrednosti.StringUEnumeraciju
{
    public class StringUNullableStatusMaterijalaKonverter : ITypeConverter<string, StatusMaterijala?>
    {
        private readonly IPomocnikParser _pomocnikParser;

        public StringUNullableStatusMaterijalaKonverter(IPomocnikParser pomocnikParser)
        {
            _pomocnikParser = pomocnikParser;
        }
        public StatusMaterijala? Convert(string izvor, StatusMaterijala? destinacija, ResolutionContext context)
        {
            return _pomocnikParser.ParsiranjeStatusaMaterijalaIzStringa(izvor);
        }
    }
}