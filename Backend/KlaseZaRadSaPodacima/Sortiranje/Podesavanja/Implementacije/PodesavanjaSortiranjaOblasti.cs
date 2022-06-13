using System;
using System.Collections.Generic;
using System.Linq;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.Sortiranje.Podesavanja.Interfejsi;
using Backend.KlaseZaRadSaPodacima.Sortiranje.SortiranjeEnumeracije;

namespace Backend.KlaseZaRadSaPodacima.Sortiranje.Podesavanja.Implementacije
{
    public class PodesavanjaSortiranjaOblasti : IPodesavanjaSortiranjaOblasti
    {
        public Func<IQueryable<OblastEntitet>, IQueryable<OblastEntitet>> podrazumevanoSortiranje => oblastSkup => oblastSkup.OrderByDescending(oblast => oblast.Putanja);

        public Dictionary<Enum, Func<IQueryable<OblastEntitet>, IQueryable<OblastEntitet>>> SkupPodesavanja => new Dictionary<Enum, Func<IQueryable<OblastEntitet>, IQueryable<OblastEntitet>>>()
        {

            {SortiranjeOblasti.Naziv_Rastuce, oblastSkup => oblastSkup.OrderBy(oblast => oblast.Naziv)},
            {SortiranjeOblasti.Naziv_Opadajuce, oblastSkup => oblastSkup.OrderByDescending(oblast => oblast.Naziv)},
            {SortiranjeOblasti.Putanja_Opadajuce, oblastSkup => oblastSkup.OrderByDescending(oblast => oblast.Putanja)},
            {SortiranjeOblasti.Putanja_Rastuce, oblastSkup => oblastSkup.OrderBy(oblast => oblast.Putanja)},
            {SortiranjeOblasti.Potrebno_Odobrenje, oblastSkup => oblastSkup.OrderBy(oblast => oblast.PotrebnoOdobrenje)},
        };
    }
}