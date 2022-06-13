using System;
using System.Collections.Generic;
using AutoMapper;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Izlazni.Oblasti;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Oblasti;
using Backend.KlaseZaRadSaPodacima.Entiteti;

namespace Backend.KlaseZaRadSaPodacima.AutoMapper.EntitetUOdlazniDTO
{
    public class OblastSadrzajDTOProfil : Profile
    {
        public OblastSadrzajDTOProfil()
        {
            CreateMap<OblastEntitet, OblastSadrzajDTO>();
        }
    }
}