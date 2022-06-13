using System;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Korisnici;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Materijali;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Materijali.Komentari;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Zajednicki;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Enumeracije;
using Newtonsoft.Json;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Materijali.Komentari
{
    public class BrisanjeKomentaraDTO : IPribaviKomentar
    {
        public string KorisnickoIme { get; set; }
        public string Naziv { get; set; }
        public string Ekstenzija { get; set; }
        public string Putanja { get; set; }
        public string VremeSlanja { get; set; }


        [JsonIgnore]
        public bool OcekivanaVrednostPostojanjaPutanje => true;
        [JsonIgnore]
        public bool PotrebnaValidacijaPraznihPoljaPutanje => true;
        [JsonIgnore]
        public bool OcekivanaVrednostPostojanja => true;
        [JsonIgnore]
        public bool PotrebnaValidacijaPraznihPolja => true;
        [JsonIgnore]
        public bool VremeSlanjaDodaja => false;
        [JsonIgnore]
        public Enum TipProverePostojanja => TipProverePostojanjaKomentara.Vreme_Slanja;
        [JsonIgnore]
        public string NaizvUPorukamaPostojanjaVremeSlanja => "Komentar";
    }
}