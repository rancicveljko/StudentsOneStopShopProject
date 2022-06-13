using System;
using Backend.KlaseZaRadSaPodacima.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using Backend.ProsirenjaMetoda;

namespace Backend.KlaseZaRadSaPodacima.PomocneKlase.Implementacije.PomocniciValidatora
{
    public class PomocnikParser : IPomocnikParser
    {
        public Uloga? ParsiranjeUlogeIzStringa(string stringUloga) => Enum.TryParse(stringUloga, out Uloga uloga) ? uloga : null;
        public DateTime? ParsiranjeVremenaIzStringaUniversalTime(string stringVreme) => DateTime.TryParse(stringVreme, out DateTime vreme) ? vreme.SkratiMilisekunde().ToUniversalTime() : null;
        public DateTime? ParsiranjeVremenaIzStringa(string stringVreme) => DateTime.TryParse(stringVreme, out DateTime vreme) ? vreme.SkratiMilisekunde() : null;
        public bool? ParsiranjeBoolIzStringa(string stringBool) => bool.TryParse(stringBool, out bool boolean) ? boolean : null;
        public int? ParsiranjeIntIzStringa(string stringInt) => int.TryParse(stringInt, out int Int) ? Int : null;
        public StatusKorisnickogNaloga? ParsiranjeStatusaKorisnickogNalogaIzString(string stringStatusKorisnickogNaloga) => Enum.TryParse<StatusKorisnickogNaloga>(stringStatusKorisnickogNaloga, out StatusKorisnickogNaloga statusKorisnickogNaloga) ? statusKorisnickogNaloga : null;
        public TipAdministratorskogZahteva? ParsiranjeTipaAdminZahtevaIzStringa(string stringTipZahteva) => Enum.TryParse(stringTipZahteva, out TipAdministratorskogZahteva tipZahteva) ? tipZahteva : null;
        public TipOcene? ParsiranjeTipaOceneIzStringa(string stringTipOcene) => Enum.TryParse(stringTipOcene, out TipOcene tipOcene) ? tipOcene : null;
        public OsnovniKorisnikPrivilegije? ParsiranjePrivilegijaOsnovnogKorisnikaIzStringa(string stringPrivilegije) => Enum.TryParse(stringPrivilegije, out OsnovniKorisnikPrivilegije privilegije) ? privilegije : null;
        public StatusMaterijala? ParsiranjeStatusaMaterijalaIzStringa(string stringStatusMaterijala) => Enum.TryParse(stringStatusMaterijala, out StatusMaterijala statusMaterijala) ? statusMaterijala : null;
        public TipIzmene? ParsiranjeTipaIzmeneIzStringa(string stringTipIzmene) => Enum.TryParse(stringTipIzmene, out TipIzmene tipIzmene) ? tipIzmene : null;
        public TipZahtevaZaDodavanjeIliAzuriranjeMaterijala? ParsiranjeTipaZahtevaZaManipulacijuMaterijalomIzStringa(string stringTipZahtevZaManipulacijuMaterijalom) => Enum.TryParse(stringTipZahtevZaManipulacijuMaterijalom, out TipZahtevaZaDodavanjeIliAzuriranjeMaterijala tipZahtevaZaManipulacijuMaterijalom) ? tipZahtevaZaManipulacijuMaterijalom : null;
    }
}