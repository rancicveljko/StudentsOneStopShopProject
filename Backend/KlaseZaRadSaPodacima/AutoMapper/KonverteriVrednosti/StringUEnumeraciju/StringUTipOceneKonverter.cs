using System;
using AutoMapper;
using Backend.KlaseZaRadSaPodacima.Enumeracije;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.KonverteriVrednosti.StringUEnumeraciju
{
    public class StringUTipOceneKonverter : ITypeConverter<string, TipOcene>
    {
        public TipOcene Convert(string izvor, TipOcene destinacija, ResolutionContext context)
        {
            return Enum.Parse<TipOcene>(izvor);
        }
    }
}