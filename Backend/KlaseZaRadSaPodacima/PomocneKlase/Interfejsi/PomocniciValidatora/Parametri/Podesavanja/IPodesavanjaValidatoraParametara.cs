using System;
using System.Collections.Generic;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Implementacije.PomocniciValidatora.Parametri.Podesavanja.Strukture;

namespace Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri.Podesavanja
{
    public interface IPodesavanjaValidatoraParametara
    {
        Dictionary<Enum, PodesavanjaValidatoraParametaraStruct> kolekcijaPodesavanja { get; }
    }
}