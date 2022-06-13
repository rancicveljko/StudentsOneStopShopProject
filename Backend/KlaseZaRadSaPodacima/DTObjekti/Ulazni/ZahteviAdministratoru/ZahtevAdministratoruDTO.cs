using System;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Korisnici;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.ZahteviAdministratoru;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Zajednicki;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Enumeracije;
using Newtonsoft.Json;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni
{
    public class ZahtevAdministratoruDTO : IVremeSlanja, ITipZahteva, IKorisnickiNalogIzKolacica
    {
        public string Tekst { get; set; } = null;
        public string Tip { get; set; } = null;
        public string VremeSlanja { get; set; } = null;
        public string KorisnickoImeSubjekta { get; set; } = null;
        [JsonIgnore]
        public bool OcekivanaVrednostPostojanja => false;
        [JsonIgnore]
        public bool PotrebnaValidacijaPraznihPolja => true;
        [JsonIgnore]
        public bool VremeSlanjaDodaja => true;
        [JsonIgnore]
        public Enum TipProverePostojanja => TipProverePostojanjaAdministratorskihZahteva.Vreme_Slanja;
        [JsonIgnore]
        public string NaizvUPorukamaPostojanjaVremeSlanja => "Administratorski zahtev";
    }
}