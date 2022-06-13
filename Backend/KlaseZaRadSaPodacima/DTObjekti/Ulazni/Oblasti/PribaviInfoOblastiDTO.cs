using System;
using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Oblasti;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Zajednicki;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.ZajednickiUslovni;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;
using Backend.KlaseZaRadSaPodacima.Sortiranje.SortiranjeEnumeracije;
using Newtonsoft.Json;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Oblasti
{
    public class PribaviInfoOblastiDTO : IIndeksi, INazivIPutanjaOblasti, IPotrebnoOdobrenje, IKriterijumSortiranja
    {
        public string OdIndeksa { get; set; } = PodrazumevaneVrednosti.OdIndeksa;
        public string Koliko { get; set; } = PodrazumevaneVrednosti.Koliko;

        public string Putanja { get; set; } = null;
        public string Naziv { get; set; } = null;
        public string PotrebnoOdobrenje { get; set; } = null;
        public string KriterijumSortiranja { get; set; } = null;


        [JsonIgnore]
        public bool OcekivanaVrednostPostojanja => true;

        [JsonIgnore]
        public bool PotrebnaValidacijaPraznihPolja => false;

        [JsonIgnore]
        public Type Repozitorijum => typeof(IOblastRepozitorijum);
        [JsonIgnore]
        public string parametarPorukeValidacijeIndeksa => "Oblasti";
        [JsonIgnore]
        public bool OcekivanaVrednostPostojanjaPutanje => true;
        [JsonIgnore]
        public bool PotrebnaValidacijaPraznihPoljaPutanje => false;

        [JsonIgnore]
        public Type TipEnumeracije => typeof(SortiranjeOblasti);
    }
}