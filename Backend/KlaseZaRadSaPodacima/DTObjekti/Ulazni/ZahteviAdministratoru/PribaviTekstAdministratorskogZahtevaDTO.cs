using System;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Korisnici;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.ZahteviAdministratoru;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Zajednicki;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Enumeracije;
using Newtonsoft.Json;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni
{
    public class PribaviTekstAdministratorskogZahtevaDTO : IVremeSlanja, IAutorAdministratorskogZahteva
    {
        public string VremeSlanja { get; set; }
        public string KorisnickoImeAutora { get; set; }
        [JsonIgnore]
        public bool PotrebnaValidacijaPraznihPolja => true;
        [JsonIgnore]
        public bool OcekivanaVrednostPostojanja => true;
        [JsonIgnore]
        public bool VremeSlanjaDodaja => false;
        [JsonIgnore]
        public Enum TipProverePostojanja => TipProverePostojanjaAdministratorskihZahteva.Vreme_Slanja;
        [JsonIgnore]
        public string NaizvUPorukamaPostojanjaVremeSlanja => "Administratorski zahtev";
    }
}