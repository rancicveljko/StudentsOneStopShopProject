using AutoMapper;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.KonverteriVrednosti.StringUCestiTip
{
    public class StringUBoolKonverter : ITypeConverter<string, bool>
    {
        public bool Convert(string izvor, bool destinacija, ResolutionContext context)
        {
            return bool.Parse(izvor);
        }
    }
}