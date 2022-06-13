using System;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Materijali;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Zajednicki;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Enumeracije;
using Newtonsoft.Json;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Materijali.Komentari
{
    public class DodajKomentarDTO : IPutanjaNazivIEkstenzijaMaterijala, IVremeSlanja, ITekst, IKorisnickiNalogIzKolacica
    {
        public string VremeSlanja { get; set; }
        public string Naziv { get; set; }
        public string Ekstenzija { get; set; }
        public string Putanja { get; set; }
        public string Tekst { get; set; }
        public string VremeSlanjaOdgovor { get; set; } = null;
        public string KorisnickoImeOdgovor { get; set; } = null;

        [JsonIgnore]
        public bool VremeSlanjaDodaja => true;
        [JsonIgnore]
        public Enum TipProverePostojanja => TipProverePostojanjaKomentara.Vreme_Slanja;
        [JsonIgnore]
        public string NaizvUPorukamaPostojanjaVremeSlanja => "Komentar";
        [JsonIgnore]
        public bool PotrebnaValidacijaPraznihPolja => true;
        [JsonIgnore]
        public int MaxDuzina => 50;
        [JsonIgnore]
        public string NazivUPorukamaPostojanjaValidatoraTeksta => "Komentar";
        [JsonIgnore]
        public bool OcekivanaVrednostPostojanjaPutanje => true;
        [JsonIgnore]
        public bool PotrebnaValidacijaPraznihPoljaPutanje => true;
        [JsonIgnore]
        public bool OcekivanaVrednostPostojanja => true;
    }
}