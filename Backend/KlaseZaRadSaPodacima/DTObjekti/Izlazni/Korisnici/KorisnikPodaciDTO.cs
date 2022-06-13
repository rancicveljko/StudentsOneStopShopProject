using System.Collections.Generic;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.Enumeracije;
using Newtonsoft.Json;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Izlazni.Korisnici
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class KorisnikPodaciDTO
    {
        public string Ime { get; set; } = null;
        public string Prezime { get; set; } = null;
        public string Email { get; set; } = null;
        public string IDBroj { get; set; } = null;
        public OsnovniKorisnikPrivilegije? Privilegije { get; set; } = null;
        public IList<string> NadlezanZaOblasti { get; set; } = null;

    }
}