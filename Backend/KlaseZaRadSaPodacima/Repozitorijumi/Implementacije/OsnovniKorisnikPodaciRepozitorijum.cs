using System.Linq;
using Backend.KlaseZaRadSaPodacima.DBContexti;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.Repozitorijumi.Implementacije
{
    public class OsnovniKorisnikPodaciRepozitorijum : OsnovniRepozitorijum<OsnovniKorisnikPodaciEntitet>, IOsnovniKorisnikPodaciRepozitorijum
    {
        public OsnovniKorisnikPodaciRepozitorijum(BazaDbContext context) : base(context)
        {
        }

        public OsnovniKorisnikPodaciEntitet PribaviPoKorisnikID(int ID)
        {
            return _context.Set<OsnovniKorisnikPodaciEntitet>().Where(osnKorPod => osnKorPod.KorisnikID == ID).FirstOrDefault();
        }
    }
}