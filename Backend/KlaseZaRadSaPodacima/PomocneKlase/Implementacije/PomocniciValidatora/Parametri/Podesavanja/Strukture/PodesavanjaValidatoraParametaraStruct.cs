using System;
using System.Linq.Expressions;
using Backend.KlaseZaRadSaPodacima.Entiteti.Interfejsi;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.PomocneKlase.Implementacije.PomocniciValidatora.Parametri.Podesavanja.Strukture
{
    public struct PodesavanjaValidatoraParametaraStruct
    {
        public PodesavanjaValidatoraParametaraStruct(Func<string, bool> funkcijaProvere, string parametarPorukaPostojanja, string parametarPorukaIzuzetka)
        {
            this.FunkcijaProvere = funkcijaProvere;
            this.ParametarPorukaPostojanja = parametarPorukaPostojanja;
            this.ParametarPorukaIzuzetka = parametarPorukaIzuzetka;
        }
        public Func<string, bool> FunkcijaProvere { get; private set; }
        public string ParametarPorukaPostojanja { get; private set; }
        public string ParametarPorukaIzuzetka { get; private set; }
    }
}