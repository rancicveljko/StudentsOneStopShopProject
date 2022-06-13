using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Oblasti;
using Newtonsoft.Json;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Oblasti
{
    public class AzuriranjeOblastiDTO : INazivIPutanjaOblasti
    {
        public string Putanja { get; set; } = null;
        public string Naziv { get; set; } = null;
        public string PotrebnoOdobrenje { get; set; } = null;

        [JsonIgnore]
        public bool OcekivanaVrednostPostojanja => false;
        [JsonIgnore]
        public bool PotrebnaValidacijaPraznihPolja => false;
        [JsonIgnore]
        public bool OcekivanaVrednostPostojanjaPutanje => true;
        [JsonIgnore]
        public bool PotrebnaValidacijaPraznihPoljaPutanje => true;
    }
}