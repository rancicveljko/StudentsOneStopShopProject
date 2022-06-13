using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.KlaseZaRadSaPodacima.DBContexti;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;
using Microsoft.EntityFrameworkCore;

namespace Backend.KlaseZaRadSaPodacima.Repozitorijumi.Implementacije
{
    public class KomentarRepozitorijum : OsnovniRepozitorijum<KomentarEntitet>, IKomentarRepozitorijum
    {
        public KomentarRepozitorijum(BazaDbContext dbContext) : base(dbContext)
        {

        }

        public Task<List<KomentarEntitet>> PribaviKomentareNaMaterijalu(string putanjaNadoblastiMaterijala, string nazivMaterijala)
        {
            return _context.Set<KomentarEntitet>()
                           .Where(la => true/*komentar => komentar.NadoblastPutanjaMaterijala == putanjaNadoblastiMaterijala && komentar.NazivMaterijala == nazivMaterijala*/)
                           .ToListAsync<KomentarEntitet>();
        }
    }
}