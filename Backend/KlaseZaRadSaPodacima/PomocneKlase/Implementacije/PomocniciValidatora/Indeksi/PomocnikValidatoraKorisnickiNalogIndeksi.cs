using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Indeksi;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.PomocneKlase.Implementacije.PomocniciValidatora.Indeksi
{
    public class PomocnikValidatoraKorisnickiNalogIndeksi : PomocnikValidatoraIndeksi, IPomocnikValidatoraKorisnickiNalogIndeksi
    {
        private readonly IKorisnickiNalogRepozitorijum _korisnickiNalogRepozitorijum;

        public PomocnikValidatoraKorisnickiNalogIndeksi(IKorisnickiNalogRepozitorijum korisnickiNalogRepozitorijum)
        {
            _korisnickiNalogRepozitorijum = korisnickiNalogRepozitorijum;
        }
      /*  public override bool proveraValidnostiIndeksa(string odIndeksaString, string kolikoString, out string poruka)
        {
            return proveraValidnostiIndeksa(odIndeksaString,
                                            kolikoString,
                                            _korisnickiNalogRepozitorijum.BrojRedova,
                                            out poruka);
        }*/}
}