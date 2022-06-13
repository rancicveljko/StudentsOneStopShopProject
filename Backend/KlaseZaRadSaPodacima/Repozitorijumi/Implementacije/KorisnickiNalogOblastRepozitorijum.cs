using Backend.KlaseZaRadSaPodacima.DBContexti;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.Repozitorijumi.Implementacije
{
    public class KorisnickiNalogOblastRepozitorijum : OsnovniRepozitorijum<KorisnickiNalogOblastEntitet>, IKorisnickiNalogOblastRepozitorijum
    {
        public KorisnickiNalogOblastRepozitorijum(BazaDbContext bazaDbContext) : base(bazaDbContext)
        {

        }
    }
}