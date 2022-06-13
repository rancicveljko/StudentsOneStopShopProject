using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.KlaseZaRadSaPodacima.DBContexti;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.Enumeracije;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;
using Microsoft.EntityFrameworkCore;

namespace Backend.KlaseZaRadSaPodacima.Repozitorijumi.Implementacije
{
    public class IzmenaRepozitorijum : OsnovniRepozitorijum<IstorijaIzmenaEntitet>, IIzmenaRepozitorijum
    {
        public IzmenaRepozitorijum(BazaDbContext dbcontext) : base(dbcontext)
        {

        }
        public async Task<List<IstorijaIzmenaEntitet>> PribaviSve()
        {
            return await _context.Set<IstorijaIzmenaEntitet>().ToListAsync<IstorijaIzmenaEntitet>();
        }
        public async Task<List<IstorijaIzmenaEntitet>> PribaviSveIzmeneBrisanja()
        {
            return await _context.Set<IstorijaIzmenaEntitet>()
                                 .Where<IstorijaIzmenaEntitet>(izmena => izmena.TipIzmene == TipIzmene.Brisanje_Materijala)
                                 .ToListAsync<IstorijaIzmenaEntitet>();
        }
    }
}