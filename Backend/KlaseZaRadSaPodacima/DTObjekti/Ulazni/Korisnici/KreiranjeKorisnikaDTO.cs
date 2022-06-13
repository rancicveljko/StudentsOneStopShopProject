using System.Collections.Generic;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Korisnici;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Oblasti;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Zajednicki;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.ZajednickiUslovni;
using Newtonsoft.Json;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Korisnici
{
    public class KreiranjeKorisnikaDTO : IEmail, IIDBrojSaUlogom, IImeIPrezime, IListaPutanjaOblasti
    {
        public string Ime { get; set; } = null;
        public string Prezime { get; set; } = null;
        public string Email { get; set; } = null;


        public string Uloga { get; set; } = null;
        public string IDBroj { get; set; } = null;


        public List<string> PutanjeOblasti { get; set; } = null;
        [JsonIgnore]
        public bool OcekivanaVrednostPostojanja => false;
        [JsonIgnore]
        public bool PotrebnaValidacijaPraznihPolja => true;


    }
}