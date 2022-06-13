using System.Collections.Generic;
using Backend.KlaseZaRadSaPodacima.Enumeracije;
using Backend.KlaseZaRadSaPodacima.Entiteti.Interfejsi;
using Newtonsoft.Json;
using System;

namespace Backend.KlaseZaRadSaPodacima.Entiteti
{
    public class KorisnickiNalogEntitet : IEntitet
    {
        public Uloga Uloga { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public StatusKorisnickogNaloga StatusNaloga { get; set; }
        public DateTime PoslednjaPromena { get; set; }
        public int KorisnikID { get; set; }
        public KorisnikEntitet Korisnik { get; set; }
        public ICollection<IstorijaIzmenaEntitet> IstorijaIzmena { get; set; }
        public ICollection<KomentarEntitet> Komentari { get; set; }
        public ICollection<OcenaEntitet> Ocene { get; set; }
        public ICollection<ZahtevAdministratoruEntitet> SubjekatAdministratorskogZahteva { get; set; }
        public ICollection<ZahtevAdministratoruEntitet> AutorAdministratorskogZahteva { get; set; }
        public ICollection<ZahtevZaDodavanjeIliAzuriranjeMaterijalaEntitet> AutorZahtevaZaDodavanjeMaterijala { get; set; }
        public IList<KorisnickiNalogOblastEntitet> NadlezanZaOblasti { get; set; }

        public override string ToString()
        {
            return KorisnikID.ToString();
        }
    }
}