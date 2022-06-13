using System;
using System.Collections.Generic;
using System.Text;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Materijali;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.ZahteviZaDodavanjeIliAzuriranjeMaterijala;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Zajednicki;
using Backend.KlaseZaRadSaPodacima.Enumeracije;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Enumeracije;
using Microsoft.Extensions.Configuration;
using tusdotnet.Models;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Materijali.Materijal
{
    public class MaterijalDTO : IPutanjaNazivIEkstenzijaMaterijala, ITipZahtevaZaDodavanjeIliAzuriranjeMaterijala, IKorisnickiNalogIzKolacica, ITekst, IVremeSlanja
    {
        public MaterijalDTO()
        {

        }
        public MaterijalDTO(IConfiguration konfiguracija,
                            Dictionary<string, Metadata> metadata)
        {
            Naziv = metadata.TryGetValue(konfiguracija["TusConfig:TusObavezniMetadata:Naziv"], out Metadata nazivMetadata) ? nazivMetadata.GetString(Encoding.UTF8) : null;
            Putanja = metadata.TryGetValue(konfiguracija["TusConfig:TusObavezniMetadata:Putanja"], out Metadata putanjaMetadata) ? putanjaMetadata.GetString(Encoding.UTF8) : null;
            TipZahteva = metadata.TryGetValue(konfiguracija["TusConfig:TusObavezniMetadata:TipZahteva"], out Metadata tipZahtevaMetadata) ? tipZahtevaMetadata.GetString(Encoding.UTF8) : null;
            Tekst = metadata.TryGetValue(konfiguracija["TusConfig:TusObavezniMetadata:TekstZahteva"], out Metadata tekstZahtevaMetadata) ? tekstZahtevaMetadata.GetString(Encoding.UTF8) : null;
            Ekstenzija = OdrediEkstenziju(konfiguracija, metadata);
            VremeSlanja = metadata.TryGetValue(konfiguracija["TusConfig:TusObavezniMetadata:VremeSlanja"], out Metadata vremeSlanjaMetadata) ? vremeSlanjaMetadata.GetString(Encoding.UTF8) : null;
        }
        public string Naziv { get; set; } = null;
        public string Ekstenzija { get; set; } = null;
        public string Putanja { get; set; } = null;
        public Guid IDNaFajlSistemu { get; set; } = default;
        public StatusMaterijala status { get; set; } = default;
        public string Tekst { get; set; } = null;
        public string TipZahteva { get; set; } = null;
        public string VremeSlanja { get; set; }

        public bool VremeSlanjaDodaja => true;
        public bool PotrebnoSlanjeZahteva { get; set; } = true;

        public bool OcekivanaVrednostPostojanja => Enum.TryParse<TipZahtevaZaDodavanjeIliAzuriranjeMaterijala>(TipZahteva, out TipZahtevaZaDodavanjeIliAzuriranjeMaterijala tipZahteva) ? tipZahteva == TipZahtevaZaDodavanjeIliAzuriranjeMaterijala.Azuriranje_Postojeceg_Materijala : false;
        public bool PotrebnaValidacijaPraznihPolja => true;

        public bool OcekivanaVrednostPostojanjaPutanje => true;
        public bool PotrebnaValidacijaPraznihPoljaPutanje => true;

        public int MaxDuzina => 50;

        public string NazivUPorukamaPostojanjaValidatoraTeksta => "Tekst zahteva";

        public Enum TipProverePostojanja  => TipProverePostojanjaZahtevaZaDodavanjeIliAzuriranjeMaterijala.Vreme_Slanja;
        public string NaizvUPorukamaPostojanjaVremeSlanja => "Zahtev za dodavanje ili ažuriranje";
        private string OdrediEkstenziju(IConfiguration konfiguracija, Dictionary<string, Metadata> metadata)
        {
            TipZahtevaZaDodavanjeIliAzuriranjeMaterijala tipZahteva;
            if (!Enum.TryParse<TipZahtevaZaDodavanjeIliAzuriranjeMaterijala>(TipZahteva, out tipZahteva)) return null;
            if (tipZahteva == TipZahtevaZaDodavanjeIliAzuriranjeMaterijala.Dodavanje_Novog_Materijala)
            {
                return metadata.TryGetValue(konfiguracija["TusConfig:TusObavezniMetadata:TipFajla"], out Metadata ekstenzijaMetadata) ? konfiguracija["TusConfig:TusDozvoljeniFormati:" + ekstenzijaMetadata.GetString(Encoding.UTF8)] : null;
            }
            if (tipZahteva == TipZahtevaZaDodavanjeIliAzuriranjeMaterijala.Azuriranje_Postojeceg_Materijala)
            {
                return metadata.TryGetValue(konfiguracija["TusConfig:TusAzuriranjeMetadata:TrenutnaEkstenzijaFajla"], out Metadata ekstenzijaMetadata) ? ekstenzijaMetadata.GetString(Encoding.UTF8) : null;
            }
            return null;
        }
    }
}