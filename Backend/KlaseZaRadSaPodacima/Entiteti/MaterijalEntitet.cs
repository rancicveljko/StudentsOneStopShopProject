using System.Collections.Generic;
using Backend.KlaseZaRadSaPodacima.Enumeracije;
using Backend.KlaseZaRadSaPodacima.Entiteti.Interfejsi;
using System;

namespace Backend.KlaseZaRadSaPodacima.Entiteti
{
    public class MaterijalEntitet : IEntitet
    {
        public MaterijalEntitet()
        {
        }

        public MaterijalEntitet(string naziv,
                                string ekstenzija,
                                StatusMaterijala status,
                                Guid iDNaFajlSistemu,
                                OblastEntitet nadoblast)
        {
            Naziv = naziv;
            Ekstenzija = ekstenzija;
            Status = status;
            IDNaFajlSistemu = iDNaFajlSistemu;
            Nadoblast = nadoblast;
        }

        public Guid ID { get; set; }
        public string Naziv { get; set; }
        public string Ekstenzija { get; set; }
        public int UkupnaOcena { get; set; }
        public StatusMaterijala Status { get; set; }
        public Guid IDNaFajlSistemu { get; set; }
        public string KratakOpis { get; set; }
        public Guid NadoblastID { get; set; }
        public OblastEntitet Nadoblast { get; set; }
        public ICollection<ZahtevZaDodavanjeIliAzuriranjeMaterijalaEntitet> SubjekatZahtevaZaDodavanje { get; set; }
        public ICollection<KomentarEntitet> Komentari { get; set; }
        public ICollection<OcenaEntitet> Ocene { get; set; }
        public ICollection<IstorijaIzmenaEntitet> Izmene { get; set; }

        public override string ToString()
        {
            return ID.ToString();
        }
    }
}