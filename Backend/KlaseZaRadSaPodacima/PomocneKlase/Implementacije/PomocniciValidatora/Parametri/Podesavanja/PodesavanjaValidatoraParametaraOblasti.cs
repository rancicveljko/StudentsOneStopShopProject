using System;
using System.Collections.Generic;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Implementacije.PomocniciValidatora.Parametri.Podesavanja.Strukture;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri.Podesavanja;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.PomocneKlase.Implementacije.PomocniciValidatora.Parametri.Podesavanja
{
    public class PodesavanjaValidatoraParametaraOblasti : IPodesavanjaValidatoraParametaraOblasti
    {
        private readonly IPomocnikParser _pomocnikParser;
        private readonly IOblastRepozitorijum _oblastRepozitorijum;

        public PodesavanjaValidatoraParametaraOblasti(IOblastRepozitorijum oblastRepozitorijum,
                                                      IPomocnikParser pomocnikParser)
        {
            _pomocnikParser = pomocnikParser;
            _oblastRepozitorijum = oblastRepozitorijum;
        }
        public Dictionary<Enum, PodesavanjaValidatoraParametaraStruct> kolekcijaPodesavanja
        {
            get
            {
                return new Dictionary<Enum, PodesavanjaValidatoraParametaraStruct>()
                {
                    {TipProverePostojanjaOblasti.Putanja,new PodesavanjaValidatoraParametaraStruct(vrednost => _oblastRepozitorijum.PostojiEntitetSaUslovom(oblast=>oblast.Putanja.Equals(vrednost)), "navedenom putanjom", "putanje") },
                    {TipProverePostojanjaOblasti.Naziv_U_Nadoblasti,new PodesavanjaValidatoraParametaraStruct(vrednost => _oblastRepozitorijum.PostojiEntitetSaUslovom(oblast=>oblast.Putanja.Equals(vrednost)), "navedenim nazivom u navedenoj nadoblasti", "putanje") },
                    {TipProverePostojanjaOblasti.Naziv,new PodesavanjaValidatoraParametaraStruct(vrednost => _oblastRepozitorijum.PostojiEntitetSaUslovom(oblast=>oblast.Naziv.Equals(vrednost)), "navedenim nazivom", "naziva") },
                    {TipProverePostojanjaOblasti.PotrebnoOdobrenje,new PodesavanjaValidatoraParametaraStruct(vrednost => _oblastRepozitorijum.PostojiEntitetSaUslovom(oblast=>oblast.PotrebnoOdobrenje.Equals(vrednost)), "navedenim atributom PotrebnaVrednost", "atributa PotrebnaVrednost") }
                };
            }
        }
    }
}