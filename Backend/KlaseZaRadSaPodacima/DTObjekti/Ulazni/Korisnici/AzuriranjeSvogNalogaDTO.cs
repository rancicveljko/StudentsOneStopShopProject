using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Korisnici;
using Newtonsoft.Json;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Korisnici
{
    public class AzuriranjeSvogNalogaDTO : IEmail, IKorisnickoImeILozinka, INovaLozinka
    {
        public string KorisnickoIme { get; set; } = null;
        public string Lozinka { get; set; } = null;
        public string Email { get; set; } = null;
        public string NovaLozinka { get; set; } = null;
        [JsonIgnore]
        public bool OcekivanaVrednostPostojanja => false;
        [JsonIgnore]
        public bool PotrebnaValidacijaPraznihPolja => false;
    }
}