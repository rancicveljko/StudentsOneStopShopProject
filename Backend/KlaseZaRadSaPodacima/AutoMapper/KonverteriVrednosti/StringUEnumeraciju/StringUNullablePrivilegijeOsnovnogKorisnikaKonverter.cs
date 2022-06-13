using AutoMapper;
using Backend.KlaseZaRadSaPodacima.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.KonverteriVrednosti.StringUEnumeraciju
{
    public class StringUNullablePrivilegijeOsnovnogKorisnikaKonverter : ITypeConverter<string, OsnovniKorisnikPrivilegije?>
    {
        private readonly IPomocnikParser _pomocnikParser;

        public StringUNullablePrivilegijeOsnovnogKorisnikaKonverter(IPomocnikParser pomocnikParser)
        {
            _pomocnikParser = pomocnikParser;
        }
        public OsnovniKorisnikPrivilegije? Convert(string izvor, OsnovniKorisnikPrivilegije? destinacija, ResolutionContext context)
        {
            return _pomocnikParser.ParsiranjePrivilegijaOsnovnogKorisnikaIzStringa(izvor);
        }
    }
}