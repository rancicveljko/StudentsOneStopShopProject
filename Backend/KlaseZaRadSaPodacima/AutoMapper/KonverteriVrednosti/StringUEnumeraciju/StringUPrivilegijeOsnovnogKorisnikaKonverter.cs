using System;
using AutoMapper;
using Backend.KlaseZaRadSaPodacima.Enumeracije;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.KonverteriVrednosti.StringUEnumeraciju
{
    public class StringUPrivilegijeOsnovnogKorisnikaKonverter : ITypeConverter<string, OsnovniKorisnikPrivilegije>
    {
        public OsnovniKorisnikPrivilegije Convert(string izvor, OsnovniKorisnikPrivilegije destinacija, ResolutionContext context)
        {
            return Enum.Parse<OsnovniKorisnikPrivilegije>(izvor);
        }
    }
}