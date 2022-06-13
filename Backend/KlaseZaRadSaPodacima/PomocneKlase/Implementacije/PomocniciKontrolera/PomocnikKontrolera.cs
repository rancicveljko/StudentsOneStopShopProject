using System;
using System.Threading.Tasks;
using Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciKontrolera;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.KlaseZaRadSaPodacima.PomocneKlase.Implementacije.PomocniciKontrolera
{
    public class PomocnikKontrolera : IPomocnikKontrolera
    {
        /* public async Task<IActionResult> ValidiranjeDTOIPozivServisa<T>(Type validatorTip, T DTOZaValidaciju, Func<T,Task<IActionResult>> zadatakNakonProvere, int statusCode)
         {
             if (validatorTip.BaseType == typeof(AbstractValidator<T>))
             {
                 AbstractValidator<T> validatorInstanca = (AbstractValidator<T>)Activator.CreateInstance(validatorTip);
                 ValidationResult validacijaRezultat = validatorInstanca.Validate(DTOZaValidaciju);
                 if(validacijaRezultat.IsValid) return await zadatakNakonProvere(DTOZaValidaciju);
                 ObjectResult rezultat = new ObjectResult(validacijaRezultat.ToString("\n"));
                 rezultat.StatusCode=statusCode;
                 return rezultat;
             }   
             return new StatusCodeResult(StatusCodes.Status500InternalServerError);
         }*/
    }
}