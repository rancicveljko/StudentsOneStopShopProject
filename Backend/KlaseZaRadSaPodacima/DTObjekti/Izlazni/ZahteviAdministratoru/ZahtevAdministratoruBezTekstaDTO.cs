using System;
using Backend.KlaseZaRadSaPodacima.Enumeracije;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Izlazni
{
    public class ZahtevAdministratoruBezTekstaDTO
    {
        public string KorisnickoImeAutora { get; set; }
        public string KorisnickoImeSubjekta { get; set; }
        public DateTime VremeSlanja { get; set; }
        public TipAdministratorskogZahteva Tip { get; set; }
    }
}