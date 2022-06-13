using System;
using AutoMapper;
using Backend.KlaseZaRadSaPodacima.Enumeracije;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.KonverteriVrednosti.StringUEnumeraciju
{
    public class StringUTipZahtevaZaDodavanjeIliAzuriranjeMaterijalaKonverter : ITypeConverter<string, TipZahtevaZaDodavanjeIliAzuriranjeMaterijala>
    {
        public TipZahtevaZaDodavanjeIliAzuriranjeMaterijala Convert(string izvor, TipZahtevaZaDodavanjeIliAzuriranjeMaterijala destinacija, ResolutionContext context)
        {
            return Enum.Parse<TipZahtevaZaDodavanjeIliAzuriranjeMaterijala>(izvor);
        }
    }
}