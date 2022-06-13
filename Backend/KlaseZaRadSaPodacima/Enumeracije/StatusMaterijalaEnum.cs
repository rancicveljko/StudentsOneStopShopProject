namespace Backend.KlaseZaRadSaPodacima.Enumeracije
{
    public enum StatusMaterijala : ushort
    {
        Dostupan,
        Obrisan,
        Sakriven,
        Ceka_Potvrdu_Dodavanja,
        Dostupan_I_Ceka_Potvrdu_Azuriranja,
        Dodat_Ili_Azuriran_Sa_Greskom_Antivirusa,
        Dodat_Ili_Azuriran_Sa_Nepoznatim_Statusom_Skeniranja_Na_Viruse
    }
}