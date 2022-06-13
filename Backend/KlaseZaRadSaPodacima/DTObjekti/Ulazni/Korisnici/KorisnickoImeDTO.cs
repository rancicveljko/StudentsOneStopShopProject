using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Korisnici;
using Newtonsoft.Json;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Korisnici
{
    public class KorisnickoImeDTO : IKorisnickoIme
    {
        public string KorisnickoIme { get; set; } = null;
        [JsonIgnore]
        public bool OcekivanaVrednostPostojanja => true;
        [JsonIgnore]
        public bool PotrebnaValidacijaPraznihPolja => true;
    }
}