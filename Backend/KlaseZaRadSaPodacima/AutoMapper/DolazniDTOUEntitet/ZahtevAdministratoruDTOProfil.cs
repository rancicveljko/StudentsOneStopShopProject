using System;
using AutoMapper;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.Enumeracije;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.DolazniDTOUEntitet
{
    public class ZahtevAdministratoruDTOProfil : Profile
    {
        public ZahtevAdministratoruDTOProfil()
        {
            CreateMap<ZahtevAdministratoruDTO, ZahtevAdministratoruEntitet>().ForMember(destinacija => destinacija.Subjekat,
                                                                                        map => map.MapFrom(izvor => izvor.KorisnickoImeSubjekta))
                                                                              .ForMember(destinacija => destinacija.Autor,
                                                                                         map => map.MapFrom(izvor => izvor));


        }
    }
}