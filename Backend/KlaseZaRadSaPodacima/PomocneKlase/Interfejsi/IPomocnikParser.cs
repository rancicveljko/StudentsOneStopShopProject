using System;
using Backend.KlaseZaRadSaPodacima.Enumeracije;

namespace Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi
{
    public interface IPomocnikParser
    {
        bool? ParsiranjeBoolIzStringa(string stringBool);
        int? ParsiranjeIntIzStringa(string stringInt);
        Uloga? ParsiranjeUlogeIzStringa(string stringUloga);
        TipAdministratorskogZahteva? ParsiranjeTipaAdminZahtevaIzStringa(string stringTipZahteva);
        DateTime? ParsiranjeVremenaIzStringaUniversalTime(string stringVreme);
        DateTime? ParsiranjeVremenaIzStringa(string stringVreme);
        StatusKorisnickogNaloga? ParsiranjeStatusaKorisnickogNalogaIzString(string stringStatusKorisnickogNaloga);
        TipOcene? ParsiranjeTipaOceneIzStringa(string stringTipOcene);
        OsnovniKorisnikPrivilegije? ParsiranjePrivilegijaOsnovnogKorisnikaIzStringa(string stringPrivilegije);
        StatusMaterijala? ParsiranjeStatusaMaterijalaIzStringa(string stringStatusMaterijala);
        TipIzmene? ParsiranjeTipaIzmeneIzStringa(string stringTipIzmene);
        TipZahtevaZaDodavanjeIliAzuriranjeMaterijala? ParsiranjeTipaZahtevaZaManipulacijuMaterijalomIzStringa(string stringTipZahtevZaManipulacijuMaterijalom);
    }
}