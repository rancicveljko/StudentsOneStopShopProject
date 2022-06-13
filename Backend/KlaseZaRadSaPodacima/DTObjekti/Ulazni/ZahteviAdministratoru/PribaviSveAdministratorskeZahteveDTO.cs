using System;
using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.ZahteviAdministratoru;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Zajednicki;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Indeksi;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora.Parametri.Podesavanja;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;
using Backend.KlaseZaRadSaPodacima.Sortiranje.SortiranjeEnumeracije;
using Newtonsoft.Json;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni
{
    public class PribaviSveAdministratorskeZahteveDTO : IIndeksi, ITipZahteva, IAutorISubjekatAdministratorskogZahteva, IVremeOdDo, IKriterijumSortiranja
    {
        public string OdIndeksa { get; set; } = PodrazumevaneVrednosti.OdIndeksa;
        public string Koliko { get; set; } = PodrazumevaneVrednosti.Koliko;
        public string KorisnickoImeAutora { get; set; } = null;
        public string KorisnickoImeSubjekta { get; set; } = null;
        public string OdVreme { get; set; } = null;
        public string DoVreme { get; set; } = null;
        public string Tip { get; set; } = null;
        public string KriterijumSortiranja { get; set; }


        [JsonIgnore]
        public bool OcekivanaVrednostPostojanja => true;
        [JsonIgnore]
        public bool PotrebnaValidacijaPraznihPolja => false;
        [JsonIgnore]
        public Type Repozitorijum => typeof(IAdministratorskiZahtevRepozitorijum);
        [JsonIgnore]
        public string parametarPorukeValidacijeIndeksa => "administratorskih zahteva";
        [JsonIgnore]
        public Enum TipProverePostojanjaVremenaOdDo => TipProverePostojanjaAdministratorskihZahteva.Vreme_Slanja;
        [JsonIgnore]
        public string NazivUPorukamaPostojanjaVremeOdDo => "Administratorski zahtev";
        [JsonIgnore]
        public Type PodesavanjaValidatoraParametaraVremeOdDo => typeof(IPodesavanjaValidatoraParametaraAdministratorskihZahteva);
        [JsonIgnore]
        public Type TipEnumeracije => typeof(AdministratorskiZahteviSortiranje);
    }
}