using System.Collections.Generic;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.Enumeracije;
using Backend.KlaseZaRadSaPodacima.ModeliAzuriranja.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.ModeliAzuriranja
{
    public class KorisnikAzuriranje : IModelAzuriranja
    {
        public string Ime { get; set; } = null;
        public string Prezime { get; set; } = null;
        public string KorisnickoIme { get; set; } = null;
        public string IDBroj { get; set; } = null;
        public string Email { get; set; } = null;
        public Uloga? Uloga { get; set; } = null;
        public StatusKorisnickogNaloga? StatusNaloga { get; set; } = null;
        public OsnovniKorisnikPrivilegije? Privilegije { get; set; } = null;
        public IList<KorisnickiNalogOblastEntitet> NadlezanZaOblasti { get; set; } = null;

    }
}