using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Indeksi;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.PomocneKlase.Implementacije.PomocniciValidatora.Indeksi
{
    public class PomocnikValidatoraZahtevAdministratoruIndeksi : PomocnikValidatoraIndeksi, IPomocnikValidatoraZahtevAdministratoruIndeksi
    {
        private readonly IAdministratorskiZahtevRepozitorijum _administratorskiZahtevRepozitorijum;

        public PomocnikValidatoraZahtevAdministratoruIndeksi(IAdministratorskiZahtevRepozitorijum administratorskiZahtevRepozitorijum)
        {
            _administratorskiZahtevRepozitorijum = administratorskiZahtevRepozitorijum;
        }
     /*   public override bool proveraValidnostiIndeksa(string odIndeksaString, string kolikoString, out string poruka)
        {
            return proveraValidnostiIndeksa(odIndeksaString,
                                            kolikoString,
                                            _administratorskiZahtevRepozitorijum.BrojRedova,
                                            out poruka);
        }*/
    }
}