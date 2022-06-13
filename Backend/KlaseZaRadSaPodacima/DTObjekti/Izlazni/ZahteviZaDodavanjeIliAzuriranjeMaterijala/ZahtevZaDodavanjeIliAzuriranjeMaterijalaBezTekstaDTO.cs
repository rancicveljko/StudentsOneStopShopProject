using System;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Materijali;
using Backend.KlaseZaRadSaPodacima.Enumeracije;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Izlazni.ZahteviZaDodavanjeIliAzuriranjeMaterijala
{
    public class ZahtevZaDodavanjeIliAzuriranjeMaterijalaBezTekstaDTO : IPutanjaNazivIEkstenzijaMaterijalaDTO
    {
        public string KorisnickoImeAutora { get; set; }
        public string PutanjaOblasti { get; set; }
        public string NazivMaterijala { get; set; }
        public string EkstenzijaMaterijala { get; set; }
        public DateTime VremeSlanja { get; set; }
        public TipZahtevaZaDodavanjeIliAzuriranjeMaterijala TipZahteva { get; set; }
    }
}