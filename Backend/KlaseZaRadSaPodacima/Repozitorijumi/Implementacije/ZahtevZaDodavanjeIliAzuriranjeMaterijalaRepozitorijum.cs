using Backend.KlaseZaRadSaPodacima.DBContexti;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.Repozitorijumi.Implementacije
{
    public class ZahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum : OsnovniRepozitorijum<ZahtevZaDodavanjeIliAzuriranjeMaterijalaEntitet>, IZahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum
    {
        public ZahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum(BazaDbContext dbcontext) : base(dbcontext)
        {

        }
    }
}