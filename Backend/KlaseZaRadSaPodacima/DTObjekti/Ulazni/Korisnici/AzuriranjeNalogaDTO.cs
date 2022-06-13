using System.Collections.Generic;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Korisnici;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Zajednicki;
using Newtonsoft.Json;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Korisnici
{
    public class AzuriranjeNalogaDTO : IImeIPrezime, IKorisnickoIme, IEmail, IStatusKorisnickogNaloga, IIDBrojSaUlogom, IPrivilegijeOsnovnogKorisnika, IPostojeceKorisnickoIme, IListaPutanjaOblasti
    {
        public string Ime { get; set; } = null;
        public string Prezime { get; set; } = null;
        public string KorisnickoIme { get; set; } = null;
        public string PostojeceKorisnickoIme { get; set; } = null;
        public string Email { get; set; } = null;
        public string StatusNaloga { get; set; } = null;
        public string IDBroj { get; set; } = null;
        public string Uloga { get; set; } = null;
        public string Privilegije { get; set; } = null;
        public List<string> PutanjeOblasti { get; set; } = null;
        [JsonIgnore]
        public bool PotrebnaValidacijaPraznihPolja => false;
        [JsonIgnore]
        public bool OcekivanaVrednostPostojanja => false;
        [JsonIgnore]
        public string NazivUPorukamaValidatora => "PostojeceKorisnickoIme";
    }
}