using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using tusdotnet.Models;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Materijali.Materijal
{
    public class AzuriranjeMaterijalaDTO : MaterijalDTO
    {
        public AzuriranjeMaterijalaDTO()
        {

        }
        public AzuriranjeMaterijalaDTO(IConfiguration konfiguracija,
                                       Dictionary<string, Metadata> metadata) : base(konfiguracija, metadata)
        {

        }
        public string NovaEkstenzija { get; private set; } = null;

        public void SetNovaEkstenzija(IConfiguration konfiguracija, Dictionary<string, Metadata> metadata)
        {
            NovaEkstenzija = metadata.TryGetValue(konfiguracija["TusConfig:TusObavezniMetadata:TipFajla"], out Metadata ekstenzijaMetadata) ? konfiguracija["TusConfig:TusDozvoljeniFormati:" + ekstenzijaMetadata.GetString(Encoding.UTF8)] : null;
        }
    }
}