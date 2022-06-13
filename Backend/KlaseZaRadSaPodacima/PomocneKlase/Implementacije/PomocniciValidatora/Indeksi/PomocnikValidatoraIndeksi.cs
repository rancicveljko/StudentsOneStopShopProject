using System;
using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Indeksi;
using Backend.Servisi.Enumeracije;
using Backend.Servisi.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.PomocneKlase.Implementacije.PomocniciValidatora.Indeksi
{
    public class PomocnikValidatoraIndeksi : PomocnikParser, IPomocnikValidatoraIndeksi
    {
        public bool proveraValidnostiIndeksa(string odIndeksaString, string kolikoString, Func<int> funkcijaZaBrojRedova, out string poruka)
        {
            poruka = null;
            int? odIndeksa = ParsiranjeIntIzStringa(odIndeksaString);
            if (odIndeksa == null) poruka = Poruke.PotrebnoProsleditiSaUslovom("Od indeksa", "i sme da sadrži samo cifre");
            int? koliko = ParsiranjeIntIzStringa(kolikoString);
            if (koliko == null) poruka = Poruke.PotrebnoProsleditiSaUslovom("Koliko", "i sme da sadrži samo cifre");
            int brojNaloga = funkcijaZaBrojRedova();
            if (odIndeksa < 0
                || odIndeksa > brojNaloga) poruka = Poruke.Mora("Od indeksa", $"biti pozitivan broj manji od broja postojećih korisničkih naloga: {brojNaloga}");
            if (koliko < 0) poruka = Poruke.Mora("Koliko", "biti pozitivan broj!");
            return poruka == null;
        }
       // public abstract bool proveraValidnostiIndeksa(string odIndeksaString, string kolikoString, out string poruka);
    }
}