using System;
using AutoMapper;
using Backend.KlaseZaRadSaPodacima.Enumeracije;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.KonverteriVrednosti.StringUEnumeraciju
{
    public class StringUStatusMaterijalaKonverter : ITypeConverter<string, StatusMaterijala>
    {
        public StatusMaterijala Convert(string izvor, StatusMaterijala destinacija, ResolutionContext context)
        {
            return Enum.Parse<StatusMaterijala>(izvor);
        }
    }
}