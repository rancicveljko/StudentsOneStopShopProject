using Backend.KlaseZaRadSaPodacima.DBContexti;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.Repozitorijumi.Implementacije
{
    public class MaterijalRepozitorijum : OsnovniRepozitorijum<MaterijalEntitet>, IMaterijalRepozitorijum
    {
        public MaterijalRepozitorijum(BazaDbContext dbcontext) : base(dbcontext)
        {

        }
    }
}