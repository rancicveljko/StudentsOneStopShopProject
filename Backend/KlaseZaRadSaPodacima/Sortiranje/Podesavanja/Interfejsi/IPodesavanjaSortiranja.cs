using System;
using System.Collections.Generic;
using System.Linq;
using Backend.KlaseZaRadSaPodacima.Entiteti.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.Sortiranje.Podesavanja.Interfejsi
{
    public interface IPodesavanjaSortiranja<TEntitet> where TEntitet : IEntitet
    {
        Func<IQueryable<TEntitet>, IQueryable<TEntitet>> podrazumevanoSortiranje { get; }
        Dictionary<Enum, Func<IQueryable<TEntitet>, IQueryable<TEntitet>>> SkupPodesavanja { get; }
    }
}