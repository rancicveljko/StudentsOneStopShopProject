using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Backend.KlaseZaRadSaPodacima.Entiteti.Interfejsi;
using Backend.KlaseZaRadSaPodacima.Sortiranje.Podesavanja.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi
{
    public interface IOsnovniRepozitorijum<TEntitet> where TEntitet : IEntitet
    {
        Task<TEntitet> PribaviPoID(params object[] IDVrednosti);
        Task Dodaj(TEntitet entitet, bool sacuvaj = true);
        Task Ukloni(TEntitet entitet, bool sacuvaj = true);
        Task UkloniVise(IEnumerable<TEntitet> entiteti, bool sacuvaj = true);
        Task AzurirajVise(IEnumerable<TEntitet> entiteti, bool sacuvaj = true);
        Task Azuriraj(TEntitet entitet, bool sacuvaj = true);
        Task<IEnumerable<TEntitet>> PribaviSveOdKoliko(int odIndeks,
                                                       int kolikom,
                                                       Expression<Func<TEntitet, bool>> filteri);
        IEnumerable<TEntitet> PribaviSveOdKoliko(int odIndeks,
                                                 int koliko,
                                                 Func<TEntitet, bool> filteri,
                                                 List<Expression<Func<TEntitet, object>>> zaUkljucivanje = null,
                                                 Dictionary<Expression<Func<TEntitet, object>>, List<Expression<Func<object, object>>>> ZaUgnjezdenoUkljucivanje = null,
                                                 Enum kriterijumSortiranja = null,
                                                 IPodesavanjaSortiranja<TEntitet> podesavanjeSortiranja = null);
        bool PostojiEntitetSaUslovom(Func<TEntitet, bool> uslov,
                                     List<Expression<Func<TEntitet, object>>> zaUkljucivanje = null,
                                     Dictionary<Expression<Func<TEntitet, object>>, List<Expression<Func<object, object>>>> ZaUgnjezdenoUkljucivanje = null);
        int BrojRedova();
        TEntitet PribaviSaUslovom(Expression<Func<TEntitet, bool>> uslovi,
                                  List<Expression<Func<TEntitet, object>>> zaUkljucivanje = null,
                                  Dictionary<Expression<Func<TEntitet, object>>, List<Expression<Func<object, object>>>> ZaUgnjezdenoUkljucivanje = null,
                                  Enum kriterijumSortiranja = null,
                                  IPodesavanjaSortiranja<TEntitet> podesavanjeSortiranja = null);
        Task<IEnumerable<TEntitet>> PribaviSveSaUslovomAsync(Expression<Func<TEntitet, bool>> uslovi,
                                                             List<Expression<Func<TEntitet, object>>> zaUkljucivanje = null,
                                                             Dictionary<Expression<Func<TEntitet, object>>, List<Expression<Func<object, object>>>> ZaUgnjezdenoUkljucivanje = null,
                                                             Enum kriterijumSortiranja = null,
                                                             IPodesavanjaSortiranja<TEntitet> podesavanjeSortiranja = null);
        IEnumerable<TEntitet> PribaviSveSaUslovom(Expression<Func<TEntitet, bool>> uslovi,
                                                  List<Expression<Func<TEntitet, object>>> zaUkljucivanje = null,
                                                  Dictionary<Expression<Func<TEntitet, object>>, List<Expression<Func<object, object>>>> ZaUgnjezdenoUkljucivanje = null,
                                                  Enum kriterijumSortiranja = null,
                                                  IPodesavanjaSortiranja<TEntitet> podesavanjeSortiranja = null);
        IEnumerable<TEntitet> PribaviSve(List<Expression<Func<TEntitet, object>>> zaUkljucivanje = null,
                                         Dictionary<Expression<Func<TEntitet, object>>, List<Expression<Func<object, object>>>> ZaUgnjezdenoUkljucivanje = null,
                                         Enum kriterijumSortiranja = null,
                                         IPodesavanjaSortiranja<TEntitet> podesavanjeSortiranja = null);
    }
}