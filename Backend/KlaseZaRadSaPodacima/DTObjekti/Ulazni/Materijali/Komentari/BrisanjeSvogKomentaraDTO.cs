using System;
using System.Text.Json.Serialization;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Materijali;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Materijali.Komentari;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Zajednicki;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Enumeracije;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Materijali.Komentari
{
    public class BrisanjeSvogKomentaraDTO : IPribaviKomentar
    {
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
        public string NaizvUPorukamaPostojanjaVremeSlanja => "Nijedan komentar, čiji ste Vi autor,";
        [JsonIgnore]
        public string KorisnickoIme { get; set; } = null;
    }
}