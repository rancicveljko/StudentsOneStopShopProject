using System;

namespace Backend.KlaseZaRadSaPodacima.Enumeracije
{
    [Flags]
    public enum TipAdministratorskogZahteva : ushort
    {
        Ukidanje_Privilegija_Komentarisanja = 1,
        Ukidanje_Privilegija_Ocenjivanja = 2,
        Ukidanje_Privilegija_Dodavanja_Materijala = 4,
        Blokiranje_Korisnickog_Naloga = 8,
        Deblokiranje_Korisnickog_Naloga = 16
    }
}