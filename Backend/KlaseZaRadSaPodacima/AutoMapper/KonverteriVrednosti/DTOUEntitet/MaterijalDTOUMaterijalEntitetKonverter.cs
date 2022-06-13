using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Materijali.Materijal;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.Enumeracije;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.KonverteriVrednosti.DTOUEntitet
{
    public class MaterijalDTOUMaterijalEntitetKonverter : ITypeConverter<MaterijalDTO, MaterijalEntitet>
    {
        private readonly IMaterijalRepozitorijum _materijalRepozitorijum;
        private readonly IOblastRepozitorijum _oblastRepozitorijum;

        public MaterijalDTOUMaterijalEntitetKonverter(IMaterijalRepozitorijum materijalRepozitorijum, IOblastRepozitorijum oblastRepozitorijum)
        {
            _materijalRepozitorijum = materijalRepozitorijum;
            _oblastRepozitorijum = oblastRepozitorijum;
        }
        public MaterijalEntitet Convert(MaterijalDTO izvor, MaterijalEntitet destinacija, ResolutionContext context)
        {
            var tipZahteva = Enum.Parse<TipZahtevaZaDodavanjeIliAzuriranjeMaterijala>(izvor.TipZahteva);
            if (tipZahteva == TipZahtevaZaDodavanjeIliAzuriranjeMaterijala.Azuriranje_Postojeceg_Materijala)
            {
                destinacija = _materijalRepozitorijum.PribaviSaUslovom(materijal => materijal.Nadoblast.Putanja.Equals(izvor.Putanja)
                                                                                    && materijal.Naziv.Equals(izvor.Naziv)
                                                                                    && materijal.Ekstenzija.Equals(izvor.Ekstenzija),
                                                                       new List<Expression<Func<MaterijalEntitet, object>>>() { materijal => materijal.Nadoblast });
                destinacija.Status = izvor.status;
                destinacija.Ekstenzija = (izvor as AzuriranjeMaterijalaDTO).NovaEkstenzija;
                if (!izvor.PotrebnoSlanjeZahteva) destinacija.IDNaFajlSistemu = izvor.IDNaFajlSistemu;
            }
            else if (tipZahteva == TipZahtevaZaDodavanjeIliAzuriranjeMaterijala.Dodavanje_Novog_Materijala)
            {
                destinacija = new MaterijalEntitet(izvor.Naziv,
                                                   izvor.Ekstenzija,
                                                   izvor.status,
                                                   izvor.IDNaFajlSistemu,
                                                  _oblastRepozitorijum.PribaviSaUslovom(oblast => oblast.Putanja.Equals(izvor.Putanja)));

                destinacija.KratakOpis = (izvor as DodavanjeMaterijalaDTO).KratakOpis;
            }
            return destinacija;
        }
    }
}