using System;
using AutoMapper;
using Backend.ProsirenjaMetoda;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.KonverteriVrednosti.StringUCestiTip
{
    public class StringUVremeKonverter : ITypeConverter<string, DateTime>
    {
        public DateTime Convert(string izvor, DateTime destinacija, ResolutionContext context)
        {
            var vreme = DateTime.Parse(izvor);
            return vreme.SkratiMilisekunde().ToUniversalTime();
        }
    }
}