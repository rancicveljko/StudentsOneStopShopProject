using System;
using System.Threading.Tasks;
using AutoMapper;
using Backend.KlaseZaRadSaPodacima.Filteri.Interfejsi;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni;
using Backend.KlaseZaRadSaPodacima.Entiteti;
using Backend.KlaseZaRadSaPodacima.Repozitorijumi.Interfejsi;
using Calabonga.PredicatesBuilder;
using EntityFramework.Exceptions.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciServisa;
using Backend.KlaseZaIzgradnjuStringova;
using System.Security.Claims;
using System.Linq;
using Backend.KlaseZaRadSaPodacima.Enumeracije;
using Backend.KlaseZaRadSaPodacima.Entiteti.Interfejsi;
using Backend.KlaseZaRadSaPodacima.ModeliAzuriranja.Interfejsi;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Collections;
using Backend.KlaseZaRadSaPodacima.Sortiranje.Podesavanja.Interfejsi;

namespace Backend.KlaseZaRadSaPodacima.PomocneKlase.Implementacije.PomocniciServisa
{
    public class PomocnikServisa : IPomocnikServisa
    {
        private bool PomocnikKreiranjaPredikta(TipFiltriranja tipFiltriranja, object entitet, PropertyInfo prop, object vrednost)
        {

            if (entitet != null)
            {
                var entitetVrednost = prop.GetValue(entitet);
                switch (tipFiltriranja)
                {
                    case TipFiltriranja.Manje_Od:
                        return (int)entitetVrednost < (int)vrednost;
                    case TipFiltriranja.Vece_Od:
                        return (int)entitetVrednost > (int)vrednost;
                    case TipFiltriranja.Manje_Od_Vreme:
                        return (DateTime)entitetVrednost < (DateTime)vrednost;
                    case TipFiltriranja.Vece_Od_Vreme:
                        return (DateTime)entitetVrednost > (DateTime)vrednost;
                    case TipFiltriranja.Jednaka_vrednost:
                        return entitetVrednost.ToString() == vrednost.ToString();
                    case TipFiltriranja.Kolekcija_Sadrzi:
                        {
                            IList lista = (IList)entitetVrednost;
                            IList listaVrednosti = (IList)vrednost;
                            foreach (var item in listaVrednosti)
                            {
                                if (lista.Contains(item)) return true;
                            }
                            return false;
                        }
                    case TipFiltriranja.Null_Kljuc:
                        {
                            if (vrednost != null && entitetVrednost != null) return vrednost.ToString() == entitetVrednost.ToString();
                            else return vrednost == null && entitetVrednost == null;
                        }
                    default:
                        return false;
                }

            }
            return false;
        }
        public IEnumerable<TEntitet> PribaviSveOdKolikoSaFilterima<TEntitet>(IFilter filterDTO,
                                                                             IOsnovniRepozitorijum<TEntitet> repozitorijum,
                                                                             int odIndeksa,
                                                                             int koliko,
                                                                             Dictionary<Type, string[]> propsZaPreskociti,
                                                                             List<Expression<Func<TEntitet, object>>> zaUkljucivanje = null,
                                                                             Dictionary<Expression<Func<TEntitet, object>>, List<Expression<Func<object, object>>>> ZaUgnjezdenoUkljucivanje = null,
                                                                             Enum kriterijumSortiranja = null,
                                                                             IPodesavanjaSortiranja<TEntitet> podesavanjaSortiranja = null) where TEntitet : IEntitet
        {
            if (propsZaPreskociti != null)
            {
                var filterIzraz = PredicateBuilder.True<TEntitet>();
                foreach (var prop in filterDTO.GetType()
                                              .GetProperties())
                {
                    int brojSlovaZaPreskociti;
                    TipFiltriranja tipFiltriranja = OdrediTipFiltriranja(prop, out brojSlovaZaPreskociti);
                    var vrednost = prop.GetValue(filterDTO);
                    PropertyInfo entitetProp;
                    if (vrednost != null || tipFiltriranja == TipFiltriranja.Null_Kljuc)
                    {
                        if ((entitetProp = typeof(TEntitet)
                                                  .GetProperty(prop.Name.Remove(0, brojSlovaZaPreskociti))) != null
                                                  && (entitetProp.PropertyType.Equals(prop.PropertyType)
                                                      || typeof(Nullable<>).MakeGenericType(entitetProp.PropertyType).Equals(prop.PropertyType)
                                                      || (entitetProp.PropertyType.IsAssignableTo(typeof(IEnumerable)) && entitetProp.PropertyType.GetGenericArguments().Contains(prop.PropertyType))))
                        {
                            filterIzraz = filterIzraz.And(entitet => PomocnikKreiranjaPredikta(tipFiltriranja, entitet, entitetProp, vrednost));
                            continue;
                        };
                        foreach (var entprop in typeof(TEntitet)
                                                                .GetProperties()
                                                                .Where(propTip => propTip.PropertyType.IsClass
                                                                        && propTip.PropertyType.IsAssignableTo(typeof(IEntitet))
                                                                        && !propsZaPreskociti[typeof(TEntitet)].Contains(propTip.Name)))
                        {
                            var listaPoziva = new List<PropertyInfo>();
                            filterIzraz = KreirajPredikatPomocnikKljuc(entprop,
                                                                       vrednost,
                                                                       tipFiltriranja,
                                                                       prop,
                                                                       filterIzraz,
                                                                       propsZaPreskociti,
                                                                       listaPoziva,
                                                                       brojSlovaZaPreskociti);
                        }

                    }
                }
                return repozitorijum.PribaviSveOdKoliko(odIndeksa,
                                                        koliko,
                                                        filterIzraz.Compile(),
                                                        zaUkljucivanje,
                                                        ZaUgnjezdenoUkljucivanje,
                                                        kriterijumSortiranja,
                                                        podesavanjaSortiranja);
            }
            else return new List<TEntitet>();
        }
        private Expression<Func<TEntitet, bool>> KreirajPredikatPomocnikKljuc<TEntitet>(PropertyInfo tipEntiteta,
                                                                                        object vrednost,
                                                                                        TipFiltriranja tipFiltriranja,
                                                                                        PropertyInfo propInfo,
                                                                                        Expression<Func<TEntitet, bool>> predikat,
                                                                                        Dictionary<Type, string[]> propsZaPreskociti,
                                                                                        List<PropertyInfo> listaPoziva,
                                                                                        int brojSlovaZaPreskociti) where TEntitet : IEntitet
        {
            foreach (var prop in tipEntiteta.PropertyType
                                                 .GetProperties()
                                                 .Where(propTip => !propsZaPreskociti[tipEntiteta.PropertyType].Contains(propTip.Name)))
            {
                if (prop.Name.Equals(propInfo.Name.Remove(0, brojSlovaZaPreskociti))
                    && (prop.PropertyType.Equals(propInfo.PropertyType)
                        || typeof(Nullable<>).MakeGenericType(prop.PropertyType).Equals(propInfo.PropertyType)))
                {
                    predikat = predikat.And(entitet => PomocnikKreiranjaPredikta(tipFiltriranja, VrednostZaProslediti(entitet, listaPoziva, tipEntiteta), prop, vrednost));
                    return predikat;
                }
                if (prop.PropertyType.IsClass && prop.PropertyType.IsAssignableTo(typeof(IEntitet)))
                {
                    listaPoziva.Add(tipEntiteta);
                    return KreirajPredikatPomocnikKljuc(prop,
                                                        vrednost,
                                                        tipFiltriranja,
                                                        propInfo,
                                                        predikat,
                                                        propsZaPreskociti,
                                                        listaPoziva,
                                                        brojSlovaZaPreskociti);
                }
            }
            return predikat;
        }
        private object VrednostZaProslediti(IEntitet entitet, List<PropertyInfo> listaPoziva, PropertyInfo tipEntiteta)
        {
            if (listaPoziva.Count == 0) return tipEntiteta.GetValue(entitet);
            object zaListu = entitet;
            foreach (var item in listaPoziva)
            {
                zaListu = item.GetValue(zaListu);
            }
            return tipEntiteta.GetValue(zaListu);
        }

        private TipFiltriranja OdrediTipFiltriranja(PropertyInfo propInfo, out int brojSlovaZaPreskociti)
        {
            if (propInfo.Name.Contains(FilterPrefiksi.Do_Vreme))
            {
                brojSlovaZaPreskociti = 7;
                return TipFiltriranja.Manje_Od_Vreme;
            }
            if (propInfo.Name.StartsWith(FilterPrefiksi.Od_Vreme))
            {
                brojSlovaZaPreskociti = 7;
                return TipFiltriranja.Vece_Od_Vreme;
            }
            if (propInfo.Name.StartsWith(FilterPrefiksi.Od))
            {
                brojSlovaZaPreskociti = 2;
                return TipFiltriranja.Vece_Od;
            }
            if (propInfo.Name.StartsWith(FilterPrefiksi.Do))
            {
                brojSlovaZaPreskociti = 2;
                return TipFiltriranja.Manje_Od;
            }
            if (propInfo.Name.StartsWith(FilterPrefiksi.Sadrzi))
            {
                brojSlovaZaPreskociti = 6;
                return TipFiltriranja.Kolekcija_Sadrzi;
            }
            if (propInfo.Name.StartsWith(FilterPrefiksi.Null))
            {
                brojSlovaZaPreskociti = 4;
                return TipFiltriranja.Null_Kljuc;
            }
            brojSlovaZaPreskociti = 0;
            return TipFiltriranja.Jednaka_vrednost;
        }

        public IActionResult ProveraIzvrsenostiZadatka(Task zadatak, int okStatus, string poruka)
        {
            return zadatak.IsCompletedSuccessfully ? new ObjectResult(poruka) { StatusCode = okStatus } : new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }

        public IActionResult RukovalacGreskamaBazePodataka(Exception izuzetak)
        {
            string poruka;
            Console.WriteLine(izuzetak);
            Console.WriteLine(izuzetak.Message);
            switch (izuzetak)
            {
                case UniqueConstraintException uniqueConstraintException:
                    poruka = "Prekršen uslov jedinstvenosti!";
                    break;
                case CannotInsertNullException cannotInsertNullException:
                    poruka = "Ne sme biti null vrednosti!";
                    break;
                case MaxLengthExceededException maxLengthExceededException:
                    poruka = "Prekoračena maksimalna dužina polja!";
                    break;
                case NumericOverflowException numericOverflowException:
                    poruka = "Preveliki broj!";
                    break;
                case ReferenceConstraintException referenceConstraintException:
                    poruka = "Pogrešna vrednost stranog ključa!";
                    break;
                default: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
            return new BadRequestObjectResult(poruka);
        }

        public async Task AzurirajEntitet<TEntitet, TDTO>(TDTO dto,
                                                          TEntitet entitet,
                                                          IOsnovniRepozitorijum<TEntitet> repozitorijum = null,
                                                          Dictionary<Type, string[]> propsZaPreskociti = null) where TEntitet : IEntitet where TDTO : IModelAzuriranja
        {
            if (propsZaPreskociti != null)
            {
                foreach (var prop in dto.GetType()
                                        .GetProperties())
                {
                    var vrednost = prop.GetValue(dto);
                    PropertyInfo entitetProp;
                    if (vrednost != null)
                    {
                        if ((entitetProp = entitet.GetType()
                                                  .GetProperty(prop.Name)) != null
                                                  && (entitetProp.PropertyType.Equals(prop.PropertyType)
                                                      || typeof(Nullable<>).MakeGenericType(entitetProp.PropertyType).Equals(prop.PropertyType)))
                        {
                            entitetProp.SetValue(entitet, vrednost);
                            continue;
                        };
                        foreach (var entprop in entitet.GetType()
                                                       .GetProperties()
                                                       .Where(propTip => propTip.PropertyType.IsClass
                                                                         && propTip.PropertyType.IsAssignableTo(typeof(IEntitet))
                                                                         && !propsZaPreskociti[entitet.GetType()].Contains(propTip.Name)))
                        {
                            var propVrednost = entprop.GetValue(entitet);
                            if (propVrednost != null) entprop.SetValue(entitet, AzurirajEntitetPomocnikZaKljuc(prop, vrednost, propVrednost, propsZaPreskociti));
                        }
                    }
                }
                if (repozitorijum != null) await repozitorijum.Azuriraj(entitet);
            }
        }
        private TEntitet AzurirajEntitetPomocnikZaKljuc<TEntitet, TVrednost>(PropertyInfo propInfo, TVrednost vrednost, TEntitet entitet, Dictionary<Type, string[]> propsZaPreskociti)
        {
            if (propsZaPreskociti != null)
            {
                foreach (var prop in entitet.GetType()
                                            .GetProperties()
                                            .Where(propTip => !propsZaPreskociti[entitet.GetType()].Contains(propTip.Name)))
                {
                    if (prop.Name.Equals(propInfo.Name)
                        && (prop.PropertyType.Equals(propInfo.PropertyType)
                            || typeof(Nullable<>).MakeGenericType(prop.PropertyType).Equals(propInfo.PropertyType)))
                    {
                        prop.SetValue(entitet, vrednost);
                        return entitet;
                    }
                    if (prop.PropertyType.IsClass && prop.PropertyType.IsAssignableTo(typeof(IEntitet))) AzurirajEntitetPomocnikZaKljuc(propInfo, vrednost, prop.GetValue(entitet), propsZaPreskociti);
                }
            }
            return entitet;
        }
    }
}