using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Oblasti;
using Newtonsoft.Json;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Oblasti
{
    public class PutanjaOblastiDTO : IPutanja
    {
        public string Putanja { get; set; }
        [JsonIgnore]
        public bool OcekivanaVrednostPostojanjaPutanje => true;
        [JsonIgnore]
        public bool PotrebnaValidacijaPraznihPoljaPutanje => true;
    }
}