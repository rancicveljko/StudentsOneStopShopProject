using System;

namespace Backend.KlaseZaRadSaPodacima.Enumeracije
{
    [Flags]
    public enum OsnovniKorisnikPrivilegije : ushort
    {
        Bez_Zabrana = 1,
        Zabrana_Komentarisanja = 2,
        Zabrana_Ocenjivanja = 4,
        Zabrana_Dodavanja_Materijala = 8
    }
}

