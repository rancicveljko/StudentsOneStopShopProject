using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Backend.KlaseZaRadSaPodacima.DBContexti;
using Backend.KlaseZaRadSaPodacima.Entiteti.Interfejsi;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;
using Backend.KlaseZaRadSaPodacima.Sortiranje.Podesavanja.Interfejsi;
using Backend.KlaseZaRadSaPodacima.Sortiranje.SortiranjeEnumeracije;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Backend.KlaseZaRadSaPodacima.Repozitorijumi.Implementacije
{
    public abstract class OsnovniRepozitorijum<TEntitet> : IOsnovniRepozitorijum<TEntitet> where TEntitet : class, IEntitet, new()
    {
        protected readonly BazaDbContext _context;
        public OsnovniRepozitorijum(BazaDbContext context)
        {
            _context = context;
        }

        public async Task Azuriraj(TEntitet entitet, bool sacuvaj = true)
        {
            _context.Set<TEntitet>()
                    .Update(entitet);
            if (sacuvaj) await _context.SaveChangesAsync();
        }

        public int BrojRedova()
        {
            return _context.Set<TEntitet>().Count();
        }

        public async Task Dodaj(TEntitet entitet, bool sacuvaj = true)
        {
            await _context.Set<TEntitet>()
                          .AddAsync(entitet);
            if (sacuvaj) await _context.SaveChangesAsync();
        }

        public bool PostojiEntitetSaUslovom(Func<TEntitet, bool> uslov,
                                            List<Expression<Func<TEntitet, object>>> zaUkljucivanje = null,
                                            Dictionary<Expression<Func<TEntitet, object>>, List<Expression<Func<object, object>>>> ZaUgnjezdenoUkljucivanje = null)
        {
            return PribaviSetSaUkljucenimISortiranjem(zaUkljucivanje,
                                                      ZaUgnjezdenoUkljucivanje,
                                                      null,
                                                      null).Any(uslov);
        }

        public async Task<TEntitet> PribaviPoID(params object[] IDValues)
        {
            return await _context.Set<TEntitet>()
                                 .FindAsync(IDValues);
        }

        public TEntitet PribaviSaUslovom(Expression<Func<TEntitet, bool>> uslovi,
                                         List<Expression<Func<TEntitet, object>>> zaUkljucivanje = null,
                                         Dictionary<Expression<Func<TEntitet, object>>, List<Expression<Func<object, object>>>> ZaUgnjezdenoUkljucivanje = null,
                                         Enum kriterijumSortiranja = null,
                                         IPodesavanjaSortiranja<TEntitet> podesavanjeSortiranja = null)
        {
            return PribaviSetSaUkljucenimISortiranjem(zaUkljucivanje,
                                                      ZaUgnjezdenoUkljucivanje,
                                                      kriterijumSortiranja,
                                                      podesavanjeSortiranja).Where(uslovi)
                                                                                   .FirstOrDefault();
        }

        public async Task<IEnumerable<TEntitet>> PribaviSveOdKoliko(int odIndeksa, int koliko, Expression<Func<TEntitet, bool>> filteri)
        {
            return await _context.Set<TEntitet>()
                                 .Where(filteri)
                                 .Skip(odIndeksa)
                                 .Take(koliko)
                                 .ToListAsync<TEntitet>();
        }

        public IEnumerable<TEntitet> PribaviSveOdKoliko(int odIndeks,
                                                        int koliko,
                                                        Func<TEntitet, bool> filteri,
                                                        List<Expression<Func<TEntitet, object>>> zaUkljucivanje = null,
                                                        Dictionary<Expression<Func<TEntitet, object>>, List<Expression<Func<object, object>>>> ZaUgnjezdenoUkljucivanje = null,
                                                        Enum kriterijumSortiranja = null,
                                                        IPodesavanjaSortiranja<TEntitet> podesavanjeSortiranja = null)
        {
            var setSaUkljucenjima = PribaviSetSaUkljucenimISortiranjem(zaUkljucivanje,
                                                                       ZaUgnjezdenoUkljucivanje,
                                                                       kriterijumSortiranja,
                                                                       podesavanjeSortiranja);
            return setSaUkljucenjima
                                .Where(filteri)
                                .Skip(odIndeks - 1)
                                .Take(koliko)
                                .ToList<TEntitet>();
        }

        public async Task<IEnumerable<TEntitet>> PribaviSveSaUslovomAsync(Expression<Func<TEntitet, bool>> uslovi,
                                                                          List<Expression<Func<TEntitet, object>>> zaUkljucivanje = null,
                                                                          Dictionary<Expression<Func<TEntitet, object>>, List<Expression<Func<object, object>>>> ZaUgnjezdenoUkljucivanje = null,
                                                                          Enum kriterijumSortiranja = null,
                                                                          IPodesavanjaSortiranja<TEntitet> podesavanjeSortiranja = null)
        {
            return await PribaviSetSaUkljucenimISortiranjem(zaUkljucivanje,
                                                            ZaUgnjezdenoUkljucivanje,
                                                            kriterijumSortiranja,
                                                            podesavanjeSortiranja).Where(uslovi)
                                                                                  .ToListAsync();
        }

        public IEnumerable<TEntitet> PribaviSveSaUslovom(Expression<Func<TEntitet, bool>> uslovi,
                                                         List<Expression<Func<TEntitet, object>>> zaUkljucivanje = null,
                                                         Dictionary<Expression<Func<TEntitet, object>>, List<Expression<Func<object, object>>>> ZaUgnjezdenoUkljucivanje = null,
                                                         Enum kriterijumSortiranja = null,
                                                         IPodesavanjaSortiranja<TEntitet> podesavanjeSortiranja = null)
        {
            return PribaviSetSaUkljucenimISortiranjem(zaUkljucivanje,
                                                      ZaUgnjezdenoUkljucivanje,
                                                      kriterijumSortiranja,
                                                      podesavanjeSortiranja).Where(uslovi)
                                                                                   .ToList();
        }
        public IEnumerable<TEntitet> PribaviSve(List<Expression<Func<TEntitet, object>>> zaUkljucivanje = null,
                                                Dictionary<Expression<Func<TEntitet, object>>, List<Expression<Func<object, object>>>> ZaUgnjezdenoUkljucivanje = null,
                                                Enum kriterijumSortiranja = null,
                                                IPodesavanjaSortiranja<TEntitet> podesavanjeSortiranja = null)
        {
            return PribaviSetSaUkljucenimISortiranjem(zaUkljucivanje,
                                                      ZaUgnjezdenoUkljucivanje,
                                                      kriterijumSortiranja,
                                                      podesavanjeSortiranja).ToList();
        }
        public virtual async Task Ukloni(TEntitet entitet, bool sacuvaj = true)
        {
            _context.Set<TEntitet>()
                    .Remove(entitet);
            if (sacuvaj) await _context.SaveChangesAsync();
        }
        protected IQueryable<TEntitet> DodajSortiranje(IQueryable<TEntitet> skup,
                                                       Enum kriterijumSortiranja,
                                                       IPodesavanjaSortiranja<TEntitet> podesavanjaSortiranja)
        {
            if (kriterijumSortiranja == null) return podesavanjaSortiranja == null ? skup : podesavanjaSortiranja.podrazumevanoSortiranje(skup);
            var funkcijaZaSortiranje = podesavanjaSortiranja.SkupPodesavanja.Where(podesavanje => podesavanje.Key.ToString() == kriterijumSortiranja.ToString()).Select(podesavanje => podesavanje.Value).FirstOrDefault();
            return funkcijaZaSortiranje != null ? funkcijaZaSortiranje(skup) : podesavanjaSortiranja.podrazumevanoSortiranje(skup);
        }
        protected IQueryable<TEntitet> PribaviSetSaUkljucenimISortiranjem(List<Expression<Func<TEntitet, object>>> izrazi,
                                                                          Dictionary<Expression<Func<TEntitet, object>>, List<Expression<Func<object, object>>>> izraziZaKolekcije,
                                                                          Enum kriterijumSortiranja,
                                                                          IPodesavanjaSortiranja<TEntitet> podesavanjeSortiranja)
        {
            IQueryable<TEntitet> query = _context.Set<TEntitet>();
            if (izrazi != null && izrazi.Count != 0)
            {
                foreach (var izraz in izrazi)
                {
                    query = query.Include(izraz);
                }
            }
            if (izraziZaKolekcije != null && izraziZaKolekcije.Count != 0)
            {
                foreach (var izrazZaKolekciju in izraziZaKolekcije)
                {
                    var queryZaNadovezivanje = query.Include(izrazZaKolekciju.Key);
                    foreach (var izrazZaDodatnoUkljucenje in izrazZaKolekciju.Value)
                    {
                        queryZaNadovezivanje = queryZaNadovezivanje.ThenInclude(izrazZaDodatnoUkljucenje);
                    }
                    query = queryZaNadovezivanje;
                }
            }
            return DodajSortiranje(query, kriterijumSortiranja, podesavanjeSortiranja);
        }

        public async Task UkloniVise(IEnumerable<TEntitet> entiteti, bool sacuvaj = true)
        {
            _context.Set<TEntitet>()
                    .RemoveRange(entiteti);
            if (sacuvaj) await _context.SaveChangesAsync();
        }

        public async Task AzurirajVise(IEnumerable<TEntitet> entiteti, bool sacuvaj = true)
        {
            _context.Set<TEntitet>()
                    .UpdateRange(entiteti);
            if (sacuvaj) await _context.SaveChangesAsync();
        }
    }
}