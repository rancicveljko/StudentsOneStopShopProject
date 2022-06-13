using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Materijali;
using Newtonsoft.Json;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Materijali.Ocene
{
    public class PribaviUkupnuOcenuIKorisnickuOcenuDTO : IPutanjaNazivIEkstenzijaMaterijala
    {
        public string Naziv { get; set; }
        public string Ekstenzija { get; set; }
        public string Putanja { get; set; }
        [JsonIgnore]
        public bool OcekivanaVrednostPostojanjaPutanje => true;
        [JsonIgnore]
        public bool PotrebnaValidacijaPraznihPoljaPutanje => true;
        [JsonIgnore]
        public bool OcekivanaVrednostPostojanja => true;
        [JsonIgnore]
        public bool PotrebnaValidacijaPraznihPolja => true;
    }
}