using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.KlaseZaRadSaPodacima.DBContexti;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;
using Microsoft.EntityFrameworkCore;

namespace Backend.KlaseZaRadSaPodacima.Repozitorijumi.Implementacije
{
    public class AdministratorskiZahtevRepozitorijum : OsnovniRepozitorijum<ZahtevAdministratoruEntitet>, IAdministratorskiZahtevRepozitorijum
    {
        public AdministratorskiZahtevRepozitorijum(BazaDbContext dbcontext) : base(dbcontext)
        {

        }
        public async Task<List<ZahtevAdministratoruEntitet>> PribaviSve()
        {
            return await _context.Set<ZahtevAdministratoruEntitet>()
                                 .ToListAsync<ZahtevAdministratoruEntitet>();
        }

    }
}