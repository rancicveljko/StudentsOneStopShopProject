using System;

namespace Backend.KlaseZaRadSaPodacima.Enumeracije
{
    public enum TipZahtevaZaDodavanjeIliAzuriranjeMaterijala : ushort
    {
        Dodavanje_Novog_Materijala,
        Azuriranje_Postojeceg_Materijala,
        Dodavanje_Ili_Azuriranje_Sa_Greskom_Antivirusa,
        Dodavanje_Ili_Azuriranje_Sa_Nepoznatim_Statusom_Skeniranja_Na_Viruse
    }
}

