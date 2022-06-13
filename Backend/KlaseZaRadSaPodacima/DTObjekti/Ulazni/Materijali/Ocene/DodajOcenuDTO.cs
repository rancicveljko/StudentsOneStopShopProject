using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Materijali;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Ocene;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Zajednicki;
using Newtonsoft.Json;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Materijali.Ocene
{
    public class DodajOcenuDTO : IPutanjaNazivIEkstenzijaMaterijala, ITipOcene, IKorisnickiNalogIzKolacica
    {
        public string Naziv { get; set; }
        public string Ekstenzija { get; set; }
        public string Putanja { get; set; }
        public string TipOcene { get; set; }

        [JsonIgnore]
        public bool OcekivanaVrednostPostojanjaPutanje => true;
        [JsonIgnore]
        public bool PotrebnaValidacijaPraznihPoljaPutanje => true;
        [JsonIgnore]
        public bool OcekivanaVrednostPostojanja => true;
        [JsonIgnore]
        public bool PotrebnaValidacijaPraznihPolja => true;
        [JsonIgnore]
        public bool OcekivanaVrednostPostojanjaOcene => false;
        [JsonIgnore]
        public bool DodajOcenu { get; set; } = false;
    }
}