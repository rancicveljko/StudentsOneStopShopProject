using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Oblasti;
using Newtonsoft.Json;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Oblasti
{
    public class KreiranjeOblastiDTO : IPutanja
    {
        [JsonProperty("PutanjaNadoblasti")]
        public string Putanja { get; set; }
        public string Naziv { get; set; }
        public string PotrebnoOdobrenje { get; set; }

        [JsonIgnore]
        public bool OcekivanaVrednostPostojanja => false;
        [JsonIgnore]
        public bool PotrebnaValidacijaPraznihPolja => true;
        [JsonIgnore]
        public bool OcekivanaVrednostPostojanjaPutanje => true;
        [JsonIgnore]
        public bool PotrebnaValidacijaPraznihPoljaPutanje => true;
    }
}