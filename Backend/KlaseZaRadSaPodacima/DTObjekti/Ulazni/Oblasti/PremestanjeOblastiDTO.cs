using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Oblasti;
using Newtonsoft.Json;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Oblasti
{
    public class PremestanjeOblastiDTO : IPutanja
    {
        public string Putanja { get; set; }
        public string PutanjaNoveNadoblasti { get; set; }


        [JsonIgnore]
        public bool OcekivanaVrednostPostojanja => true;

        [JsonIgnore]
        public bool PotrebnaValidacijaPraznihPolja => true;
        [JsonIgnore]
        public bool OcekivanaVrednostPostojanjaPutanje => true;
        [JsonIgnore]
        public bool PotrebnaValidacijaPraznihPoljaPutanje => true;
    }
}