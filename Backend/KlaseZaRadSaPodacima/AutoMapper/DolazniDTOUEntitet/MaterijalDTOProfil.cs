using System;
using AutoMapper;
using Backend.KlaseZaRadSaPodacima.AutoMapper.KonverteriVrednosti.DTOUEntitet;
using Backend.KlaseZaRadSaPodacima.AutoMapper.KonverteriVrednosti.StringUEntitet;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Materijali.Materijal;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.Enumeracije;
using Backend.ProsirenjaMetoda;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.DolazniDTOUEntitet
{
    public class MaterijalDTOProfil : Profile
    {
        public MaterijalDTOProfil()
        {
            CreateMap<MaterijalDTO, DodavanjeMaterijalaDTO>();
            CreateMap<MaterijalDTO, AzuriranjeMaterijalaDTO>();

            CreateMap<MaterijalDTO, MaterijalEntitet>().ConvertUsing<MaterijalDTOUMaterijalEntitetKonverter>();

            CreateMap<MaterijalDTO, ZahtevZaDodavanjeIliAzuriranjeMaterijalaEntitet>().ForMember(destinacija => destinacija.Autor,
                                                                                                 map => map.MapFrom(izvor => izvor))
                                                                                      .ForMember(destinacija => destinacija.Materijal,
                                                                                                 map => map.MapFrom(izvor => izvor));

            CreateMap<MaterijalDTO, IstorijaIzmenaEntitet>().ForMember(destinacija => destinacija.Autor,
                                                                       map => map.MapFrom(izvor => izvor))
                                                            .ForMember(destinacija => destinacija.Materijal,
                                                                       map => map.MapFrom(izvor => izvor))
                                                            .ForMember(destinacija => destinacija.TipIzmene,
                                                                       map => map.MapFrom(izvor => Enum.Parse<TipZahtevaZaDodavanjeIliAzuriranjeMaterijala>(izvor.TipZahteva) == TipZahtevaZaDodavanjeIliAzuriranjeMaterijala.Dodavanje_Novog_Materijala ? TipIzmene.Dodavanje_Materijala : TipIzmene.Azuriranje_Materijala))
                                                            .ForMember(destinacija => destinacija.VremeIzmene,
                                                                       map => map.MapFrom(izvor => DateTime.UtcNow.SkratiMilisekunde()));
        }
    }
}