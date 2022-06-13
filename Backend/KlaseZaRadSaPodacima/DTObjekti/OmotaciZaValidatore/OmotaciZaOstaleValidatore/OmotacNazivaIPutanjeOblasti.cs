using System;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Oblasti;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.OmotaciZaValidatore.OmotaciZaOstaleValidatore
{
    public class OmotacNazivaIPutanjeOblasti : INazivIPutanjaOblasti
    {
        private bool ocekivanaVrednostPostojanjaPutanje;
        private bool ocekivanaVrednostPostojanja;
        private bool potrebnaValidacijaPraznihPoljaPutanje;
        private bool potrebnaValidacijaPraznihPolja;

        public OmotacNazivaIPutanjeOblasti(bool ocekivanaVrednostPostojanjaPutanje,
                                           bool ocekivanaVrednostPostojanja,
                                           bool potrebnaValidacijaPraznihPoljaPutanje,
                                           bool potrebnaValidacijaPraznihPolja,
                                           string naziv,
                                           string putanja,
                                           bool? nazivINazivUPutanjiJednaki)
        {
            this.ocekivanaVrednostPostojanjaPutanje = ocekivanaVrednostPostojanjaPutanje;
            this.ocekivanaVrednostPostojanja = ocekivanaVrednostPostojanja;
            this.potrebnaValidacijaPraznihPoljaPutanje = potrebnaValidacijaPraznihPoljaPutanje;
            this.potrebnaValidacijaPraznihPolja = potrebnaValidacijaPraznihPolja;
            Naziv = naziv;
            Putanja = putanja;
            NazivINazivUPutanjiJednaki = nazivINazivUPutanjiJednaki;
        }

        public string Naziv { get; set; } = null;
        public string Putanja { get; set; } = null;

        public bool OcekivanaVrednostPostojanjaPutanje => ocekivanaVrednostPostojanjaPutanje;
        public bool PotrebnaValidacijaPraznihPoljaPutanje => potrebnaValidacijaPraznihPoljaPutanje;

        public bool? NazivINazivUPutanjiJednaki { get; set; } = null;

        public bool OcekivanaVrednostPostojanja => ocekivanaVrednostPostojanja;

        public bool PotrebnaValidacijaPraznihPolja => potrebnaValidacijaPraznihPolja;
    }
}