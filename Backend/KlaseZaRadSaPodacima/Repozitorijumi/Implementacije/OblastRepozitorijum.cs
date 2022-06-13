using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Backend.KlaseZaRadSaPodacima.DBContexti;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.Repozitorijumi.Implementacije
{
    public class OblastRepozitorijum : OsnovniRepozitorijum<OblastEntitet>, IOblastRepozitorijum
    {
        public OblastRepozitorijum(BazaDbContext dbcontext) : base(dbcontext)
        {

        }

        public async Task AzurirajPutanjuZaOblastiKojeSadrzePutanju(string putanja, string novaPutanja, bool sacuvaj = true)
        {
            var oblastiSaPutanjom = PribaviSveSaUslovom(oblast => oblast.Putanja.StartsWith(putanja));
            foreach (var oblast in oblastiSaPutanjom)
            {
                oblast.Putanja = oblast.Putanja.Replace(putanja, novaPutanja);
            }
            await AzurirajVise(oblastiSaPutanjom, sacuvaj);
        }

        public string PribaviAdresuPocetnogFoldera()
        {
            return _context.Set<OblastEntitet>()
                           .Where(oblast => oblast.Nadoblast == null)
                           .First().Putanja;
        }

        public OblastEntitet PribaviPoIDSaUkljucenim(string putanja, bool ukljuciMaterijaleIPodoblasti = false)
        {
            IQueryable<OblastEntitet> query = _context.Set<OblastEntitet>();

            if (ukljuciMaterijaleIPodoblasti)
            {
                // query = PribaviSetSaUkljucenim(new List<Expression<Func<OblastEntitet, object>>> { oblast => oblast.Materijali, oblast => oblast.Podoblasti });
            }
            return query.Where(oblast => oblast.Putanja == putanja)
                        .SingleOrDefault<OblastEntitet>();
        }
    }
}