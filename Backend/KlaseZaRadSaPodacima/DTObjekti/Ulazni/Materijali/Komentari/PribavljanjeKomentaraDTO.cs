using System;
using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Korisnici;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Materijali;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Materijali.Komentari;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Zajednicki;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri.Podesavanja;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;
using Newtonsoft.Json;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Materijali.Komentari
{
    public class PribavljanjeKomentaraDTO : IIndeksi, IPutanjaNazivIEkstenzijaMaterijala, IKorisnickoIme, IVremeOdDo, IPribaviKomentar
    {
        public string OdIndeksa { get; set; } = PodrazumevaneVrednosti.OdIndeksa;
        public string Koliko { get; set; } = PodrazumevaneVrednosti.Koliko;
        public string Naziv { get; set; } = null;
        public string Ekstenzija { get; set; } = null;
        public string Putanja { get; set; } = null;
        public string KorisnickoIme { get; set; } = null;
        public string OdVreme { get; set; } = null;
        public string DoVreme { get; set; } = null;
        public string VremeSlanja { get; set; } = null;
        public string KorisnickoImeOdgovor { get; set; } = null;
        public string VremeSlanjaOdgovor { get; set; } = null;

        [JsonIgnore]
        public Type Repozitorijum => typeof(IKomentarRepozitorijum);
        [JsonIgnore]
        public string parametarPorukeValidacijeIndeksa => "komentara";
        [JsonIgnore]
        public bool OcekivanaVrednostPostojanja => true;
        [JsonIgnore]
        public bool PotrebnaValidacijaPraznihPolja => false;
        [JsonIgnore]
        public bool OcekivanaVrednostPostojanjaPutanje => true;
        [JsonIgnore]
        public bool PotrebnaValidacijaPraznihPoljaPutanje => false;
        [JsonIgnore]
        public string NazivUPorukamaPostojanjaVremeOdDo => "Komentar";
        [JsonIgnore]
        public Type PodesavanjaValidatoraParametaraVremeOdDo => typeof(IPodesavanjaValidatoraParametaraKomentara);


        public bool VremeSlanjaDodaja => false;

        public Enum TipProverePostojanja => TipProverePostojanjaKomentara.Vreme_Slanja;

        public string NaizvUPorukamaPostojanjaVremeSlanja => "Komentar";
    }
}