using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.Entiteti.Interfejsi;
using Backend.KlaseZaRadSaPodacima.Sortiranje.Podesavanja.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi
{
    public interface IKorisnickiNalogRepozitorijum : IOsnovniRepozitorijum<KorisnickiNalogEntitet>
    {
        KorisnickiNalogEntitet PribaviPoKorisnickomImenu(string korisnickoIme,
                                                         List<Expression<Func<KorisnickiNalogEntitet, object>>> zaUkljucivanje = null,
                                                         Dictionary<Expression<Func<KorisnickiNalogEntitet, object>>, List<Expression<Func<object, object>>>> izraziZaKolekcije = null,
                                                         Enum kriterijumSortiranja = null,
                                                         IPodesavanjaSortiranja<KorisnickiNalogEntitet> podesavanjeSortiranja = null);
        bool ProveriPoslednjuPromenu(string korisnickoIme, string poslednjaPromena);
        Task ResetujLozinku(string korisnickoIme);
    }
}