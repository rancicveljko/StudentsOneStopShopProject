
using System;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Zajednicki;
using Backend.KlaseZaRadSaPodacima.Enumeracije;

namespace Backend.KlaseZaRadSaPodacima.Entiteti
{
    public class ZahtevZaDodavanjeIliAzuriranjeMaterijalaEntitet : AutorMaterijalKompozitniKljucEntitet, ITekstEntitet
    {
        public string Tekst { get; set; }
        public TipZahtevaZaDodavanjeIliAzuriranjeMaterijala TipZahteva { get; set; }
        public Guid IdNaFajlSistemu { get; set; }
        public DateTime VremeSlanja { get; set; }
    }
}