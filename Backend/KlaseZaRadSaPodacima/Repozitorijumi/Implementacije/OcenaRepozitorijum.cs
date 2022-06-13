using Backend.KlaseZaRadSaPodacima.DBContexti;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.Repozitorijumi.Implementacije
{
    public class OcenaRepozitorijum : OsnovniRepozitorijum<OcenaEntitet>, IOcenaRepozitorijum
    {
        public OcenaRepozitorijum(BazaDbContext dbcontext) : base(dbcontext)
        {

        }
    }
}