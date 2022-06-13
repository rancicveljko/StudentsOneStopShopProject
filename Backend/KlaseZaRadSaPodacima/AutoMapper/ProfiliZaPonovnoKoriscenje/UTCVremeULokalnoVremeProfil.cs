using System;
using AutoMapper;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.ProfiliZaPonovnoKoriscenje
{
    public class UTCVremeULokalnoVremeProfil : Profile
    {
        public UTCVremeULokalnoVremeProfil()
        {
            CreateMap<DateTime, DateTime>().ConvertUsing(izvor => izvor.ToLocalTime());
        }
    }
}