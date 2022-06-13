using System;
using AutoMapper;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.KonverteriVrednosti.StringUCestiTip
{
    public class StringUNullableVremeKonverter : ITypeConverter<string, DateTime?>
    {
        private readonly IPomocnikParser _pomocnikParser;

        public StringUNullableVremeKonverter(IPomocnikParser pomocnikParser)
        {
            _pomocnikParser = pomocnikParser;
        }
        public DateTime? Convert(string izvor, DateTime? destinacija, ResolutionContext context)
        {
            return _pomocnikParser.ParsiranjeVremenaIzStringaUniversalTime(izvor);
        }
    }
}