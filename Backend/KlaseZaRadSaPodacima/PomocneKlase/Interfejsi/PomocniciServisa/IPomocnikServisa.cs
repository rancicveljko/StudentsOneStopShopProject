using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Backend.KlaseZaRadSaPodacima.Filteri.Interfejsi;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Backend.KlaseZaRadSaPodacima.ModeliAzuriranja.Interfejsi;
using Backend.KlaseZaRadSaPodacima.Entiteti.Interfejsi;
using Backend.KlaseZaRadSaPodacima.Sortiranje.Podesavanja.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciServisa
{
    public interface IPomocnikServisa
    {
        IActionResult ProveraIzvrsenostiZadatka(Task zadatak, int okStatus, string poruka);
        IActionResult RukovalacGreskamaBazePodataka(Exception izuzetak);
        IEnumerable<TEntitet> PribaviSveOdKolikoSaFilterima<TEntitet>(IFilter filterDTO,
                                                                      IOsnovniRepozitorijum<TEntitet> repozitorijum,
                                                                      int odIndeksa,
                                                                      int koliko,
                                                                      Dictionary<Type, string[]> propsZaPreskociti,
                                                                      List<Expression<Func<TEntitet, object>>> zaUkljucivanje = null,
                                                                      Dictionary<Expression<Func<TEntitet, object>>, List<Expression<Func<object, object>>>> ZaUgnjezdenoUkljucivanje = null,
                                                                      Enum kriterijumSortiranja = null,
                                                                      IPodesavanjaSortiranja<TEntitet> podesavanjaSortiranja = null) where TEntitet : IEntitet;
        Task AzurirajEntitet<TEntitet, TDTO>(TDTO dto,
                                             TEntitet entitet,
                                             IOsnovniRepozitorijum<TEntitet> repozitorijum = null,
                                             Dictionary<Type, string[]> imenaZaPreskociti = null) where TEntitet : IEntitet where TDTO : IModelAzuriranja;
    }


}