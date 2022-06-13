using System;
using AutoMapper;
using Backend.KlaseZaRadSaPodacima.Enumeracije;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.KonverteriVrednosti.StringUEnumeraciju
{
    public class StringUUloguKonverter : ITypeConverter<string, Uloga>
    {
        public Uloga Convert(string izvor, Uloga destinacija, ResolutionContext context)
        {
            return Enum.Parse<Uloga>(izvor);
        }
    }
}