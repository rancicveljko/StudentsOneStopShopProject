using System;
using AutoMapper;
using Backend.KlaseZaRadSaPodacima.DTObjekti.OmotaciZaValidatore.OmotaciZaOstaleValidatore;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.KonverteriVrednosti.StringUEntitet
{
    public class StringPutanjaUOblastEntitetKonverter : ITypeConverter<string, OblastEntitet>
    {
        private readonly IOblastRepozitorijum _oblastRepozitorijum;

        public StringPutanjaUOblastEntitetKonverter(IOblastRepozitorijum oblastRepozitorijum)
        {
            _oblastRepozitorijum = oblastRepozitorijum;
        }

        public OblastEntitet Convert(string izvor, OblastEntitet destinacija, ResolutionContext context)
        {
            return _oblastRepozitorijum.PribaviSaUslovom(oblast => oblast.Putanja == izvor);
        }
    }
}