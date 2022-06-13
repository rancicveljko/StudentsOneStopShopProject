using System;
using AutoMapper;
using Backend.KlaseZaRadSaPodacima.Enumeracije;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.KonverteriVrednosti.StringUEnumeraciju
{
    public class StringUStatusKorisnickogNalogaKonverter : ITypeConverter<string, StatusKorisnickogNaloga>
    {

        public StatusKorisnickogNaloga Convert(string izvor, StatusKorisnickogNaloga destinacija, ResolutionContext context)
        {
            return Enum.Parse<StatusKorisnickogNaloga>(izvor);
        }
    }
}