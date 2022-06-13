
using Backend.KlaseZaRadSaPodacima.Entiteti.Interfejsi;
using Backend.KlaseZaRadSaPodacima.Enumeracije;

namespace Backend.KlaseZaRadSaPodacima.Entiteti
{
    public class OsnovniKorisnikPodaciEntitet : IEntitet
    {
        public OsnovniKorisnikPodaciEntitet(string IDBroj)
        {
            this.IDBroj = IDBroj;
        }
        public OsnovniKorisnikPodaciEntitet()
        {

        }
        public string IDBroj { get; set; }
        public OsnovniKorisnikPrivilegije Privilegije { get; set; }
        public int KorisnikID { get; set; }
        public KorisnikEntitet Korisnik { get; set; }
    }
}