using System;
using AutoMapper;
using Backend.KlaseZaRadSaPodacima.Enumeracije;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.KonverteriVrednosti.StringUEnumeraciju
{
    public class StringUTipIzmeneKonverter : ITypeConverter<string, TipIzmene>
    {
        public TipIzmene Convert(string izvor, TipIzmene destinacija, ResolutionContext context)
        {
            return Enum.Parse<TipIzmene>(izvor);
        }
    }
}