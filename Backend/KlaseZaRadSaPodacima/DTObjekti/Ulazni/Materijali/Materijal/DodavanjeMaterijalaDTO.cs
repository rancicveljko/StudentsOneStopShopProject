using System;
using System.Collections.Generic;
using System.Text;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Materijali;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Interfejsi.Oblasti;
using Backend.KlaseZaRadSaPodacima.Enumeracije;
using Microsoft.Extensions.Configuration;
using tusdotnet.Models;

namespace Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Materijali.Materijal
{
    public class DodavanjeMaterijalaDTO : MaterijalDTO
    {
        public DodavanjeMaterijalaDTO()
        {
            
        }
        public DodavanjeMaterijalaDTO(IConfiguration konfiguracija,
                                      Dictionary<string, Metadata> metadata) : base(konfiguracija, metadata)
        { }
        public void SetKratakOpis(IConfiguration konfiguracija, Dictionary<string, Metadata> metadata)
        {
            KratakOpis = metadata.TryGetValue(konfiguracija["TusConfig:TusKreiranjeMetadata:KratakOpis"], out Metadata kratakOpisMetadata) ? kratakOpisMetadata.GetString(Encoding.UTF8) : null;
        }
        public string KratakOpis { get; private set; } = null;
        public int UkupnaOcena => 0;
    }
}