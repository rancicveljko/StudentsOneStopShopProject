using System;
using System.Text.Json.Serialization;
using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Korisnici;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.ZahteviZaDodavanjeIliAzuriranjeMaterijala;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Zajednicki;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri.Podesavanja;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.ZahteviZaDodavanjeIliAzuriranjeMaterijala
{
    public class PribaviSveZahteveZaDodavanjeIliAzuriranjeMaterijalaDTO : IIndeksi, IVremeOdDo, ITipZahtevaZaDodavanjeIliAzuriranjeMaterijala, IAutorZahtevaZaDodavanjeIliAzuriranjeMaterijala, IPutanjaNazivIEkstenzijaMaterijalaZahtevaZaDodavanjeIliAzuriranjeMaterijala
    {
        public string OdIndeksa { get; set; } = PodrazumevaneVrednosti.OdIndeksa;
        public string Koliko { get; set; } = PodrazumevaneVrednosti.Koliko;
        public string OdVreme { get; set; } = null;
        public string DoVreme { get; set; } = null;
        public string TipZahteva { get; set; } = null;
        public string KorisnickoIme { get; set; } = null;
        public string Naziv { get; set; } = null;
        public string Ekstenzija { get; set; } = null;
        public string Putanja { get; set; } = null;

        [JsonIgnore]
        public Type Repozitorijum => typeof(IZahtevZaDodavanjeIliAzuriranjeMaterijalaRepozitorijum);
        [JsonIgnore]
        public string parametarPorukeValidacijeIndeksa => "zahteva za dodavanje ili ažuriranje materijala";
        [JsonIgnore]
        public string NazivUPorukamaPostojanjaVremeOdDo => "Zahtev za dodavanje ili ažuriranje materijala";
        [JsonIgnore]
        public Type PodesavanjaValidatoraParametaraVremeOdDo => typeof(IPodesavanjaValidatoraParametaraZahtevaZaDodavanjeIliAzuriranjeMaterijala);
        [JsonIgnore]
        public bool OcekivanaVrednostPostojanja => true;
        [JsonIgnore]
        public bool PotrebnaValidacijaPraznihPolja => false;
        [JsonIgnore]
        public bool OcekivanaVrednostPostojanjaPutanje => true;
        [JsonIgnore]
        public bool PotrebnaValidacijaPraznihPoljaPutanje => false;
    }
}