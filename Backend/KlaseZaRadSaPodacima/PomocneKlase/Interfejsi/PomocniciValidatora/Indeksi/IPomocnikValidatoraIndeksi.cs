using System;
using Backend.KlaseZaRadSaPodacima.Enumeracije;

namespace Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Indeksi
{
    public interface IPomocnikValidatoraIndeksi : IPomocnikParser
    {
        bool proveraValidnostiIndeksa(string odIndeksaString, string kolikoString, Func<int> funkcijaZaBrojRedova, out string poruka);
    }
}