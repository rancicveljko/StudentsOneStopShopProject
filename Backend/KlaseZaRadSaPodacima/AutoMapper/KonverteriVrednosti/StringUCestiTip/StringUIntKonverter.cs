using AutoMapper;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.KonverteriVrednosti.StringUCestiTip
{
    public class StringUIntKonverter : ITypeConverter<string, int>
    {
        public int Convert(string izvor, int destinacija, ResolutionContext context)
        {
            return int.Parse(izvor);
        }
    }
}