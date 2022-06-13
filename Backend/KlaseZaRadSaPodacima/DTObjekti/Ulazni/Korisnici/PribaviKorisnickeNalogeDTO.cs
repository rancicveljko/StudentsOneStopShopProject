using System;
using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Korisnici;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Oblasti;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Zajednicki;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;
using Backend.KlaseZaRadSaPodacima.Sortiranje.SortiranjeEnumeracije;
using Newtonsoft.Json;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Korisnici
{
    public class PribaviKorisnickeNalogeDTO : IKorisnickoIme, IStatusKorisnickogNaloga, IIndeksi, IIDBrojSaUlogom, IPrivilegijeOsnovnogKorisnika, IImeIPrezime, IEmail, IPutanja, IKriterijumSortiranja
    {
        public string OdIndeksa { get; set; } = PodrazumevaneVrednosti.OdIndeksa;
        public string Koliko { get; set; } = PodrazumevaneVrednosti.Koliko;
        public string Uloga { get; set; } = null;
        public string StatusNaloga { get; set; } = null;
        public string KorisnickoIme { get; set; } = null;
        public string IDBroj { get; set; } = null;
        public string Privilegije { get; set; } = null;
        public string Ime { get; set; } = null;
        public string Prezime { get; set; } = null;
        public string Email { get; set; } = null;
        public string Putanja { get; set; } = null;
        public string KriterijumSortiranja { get; set; } = null;


        [JsonIgnore]
        public bool OcekivanaVrednostPostojanja => true;
        [JsonIgnore]
        public bool PotrebnaValidacijaPraznihPolja => false;
        [JsonIgnore]
        public Type Repozitorijum => typeof(IKorisnickiNalogRepozitorijum);
        [JsonIgnore]
        public string parametarPorukeValidacijeIndeksa => "korisničkih naloga";
        [JsonIgnore]
        public bool OcekivanaVrednostPostojanjaPutanje => true;
        [JsonIgnore]
        public bool PotrebnaValidacijaPraznihPoljaPutanje => false;
        [JsonIgnore]
        public Type TipEnumeracije => typeof(KorisnickiNalogSortiranje);
    }
}