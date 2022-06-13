using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Indeksi;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.PomocneKlase.Implementacije.PomocniciValidatora.Indeksi
{
    public class PomocnikValidatoraKorisnikIndeksi : PomocnikValidatoraIndeksi, IPomocnikValidatoraKorisnikIndeksi
    {
        private readonly IKorisnikRepozitorijum _korisnikRepozitorijum;

        public PomocnikValidatoraKorisnikIndeksi(IKorisnikRepozitorijum korisnikRepozitorijum)
        {
            _korisnikRepozitorijum = korisnikRepozitorijum;
        }
       /* public override bool proveraValidnostiIndeksa(string odIndeksaString, string kolikoString, out string poruka)
        {
            return proveraValidnostiIndeksa(odIndeksaString,
                                            kolikoString,
                                            _korisnikRepozitorijum.BrojRedova,
                                            out poruka);
        }*/
    }
}