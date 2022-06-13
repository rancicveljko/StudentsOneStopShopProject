using System;
using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Oblasti;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.PomocneKlase.Implementacije.PomocniciValidatora
{
    public class PomocnikValidatoraPutanje : IPomocnikValidatoraPutanje
    {
        private readonly IOblastRepozitorijum _oblastRepozitorijum;

        public PomocnikValidatoraPutanje(IOblastRepozitorijum oblastRepozitorijum)
        {
            _oblastRepozitorijum = oblastRepozitorijum;
        }
        public bool DopuniPutanju(IPutanja putanja, bool dodavanjeNaPraznuPutanju, bool proveriPutanjuKorena, out string poruka)
        {
            poruka = null;
            var putanjaPocetnogFoldera = _oblastRepozitorijum.PribaviAdresuPocetnogFoldera();
            if (dodavanjeNaPraznuPutanju && string.IsNullOrEmpty(putanja.Putanja))
            {
                putanja.Putanja = putanjaPocetnogFoldera;
                return true;
            }
            if (!string.IsNullOrEmpty(putanja.Putanja) && !putanja.Putanja.StartsWith(putanjaPocetnogFoldera) && System.Text.RegularExpressions.Regex.IsMatch(putanja.Putanja, Regex.putanja))
            {
                putanja.Putanja = putanjaPocetnogFoldera + putanja.Putanja;
                return true;
            }
            if(proveriPutanjuKorena && putanja.Putanja == putanjaPocetnogFoldera)
            {
                poruka = Poruke.NeSme("Putanja","biti putanja korenske oblasti");
                return false;
            }         
            return true;
        }
    }
}