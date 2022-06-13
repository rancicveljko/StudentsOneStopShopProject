using System;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Materijali;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.ZahteviZaDodavanjeIliAzuriranjeMaterijala;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Zajednicki;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Enumeracije;
using Newtonsoft.Json;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.ZahteviZaDodavanjeIliAzuriranjeMaterijala
{
    public class PribaviTekstZahtevaZaDodavanjeIliAzuriranjeMaterijalaDTO : IPribaviZahtevZaDodavanjeIliAzuriranjeMaterijala
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
        public Enum TipProverePostojanja => TipProverePostojanjaZahtevaZaDodavanjeIliAzuriranjeMaterijala.Vreme_Slanja;
        [JsonIgnore]
        public string NaizvUPorukamaPostojanjaVremeSlanja => "Zahtev za dodavanje ili ažuriranje materijala";
    }
}