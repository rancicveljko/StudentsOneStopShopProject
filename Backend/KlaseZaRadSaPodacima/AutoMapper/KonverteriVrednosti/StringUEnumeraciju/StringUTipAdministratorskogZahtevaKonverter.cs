using System;
using AutoMapper;
using Backend.KlaseZaRadSaPodacima.Enumeracije;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.KonverteriVrednosti.StringUEnumeraciju
{
    public class StringUTipAdministratorskogZahtevaKonverter : ITypeConverter<string, TipAdministratorskogZahteva>
    {
        public TipAdministratorskogZahteva Convert(string izvor, TipAdministratorskogZahteva destinacija, ResolutionContext context)
        {
            return Enum.Parse<TipAdministratorskogZahteva>(izvor);
        }
    }
}