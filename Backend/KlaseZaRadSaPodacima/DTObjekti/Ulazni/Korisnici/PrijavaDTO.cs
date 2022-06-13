using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Korisnici;
using Newtonsoft.Json;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Korisnici
{
    public class PrijavaDTO : IKorisnickoImeILozinka
    {
        public string KorisnickoIme { get; set; } = null;
        public string Lozinka { get; set; } = null;
        public string ZapamtiMe { get; set; } = null;
        [JsonIgnore]
        public bool OcekivanaVrednostPostojanja => true;
        [JsonIgnore]
        public bool PotrebnaValidacijaPraznihPolja => true;
    }
}