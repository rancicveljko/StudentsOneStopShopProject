using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Materijali.Komentari;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Materijali;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Zajednicki;
using FluentValidation;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.Materijali.Komentari
{
    public class PribavljanjeKomentaraValidator : AbstractValidator<PribavljanjeKomentaraDTO>
    {
        public PribavljanjeKomentaraValidator(IndeksiValidator indeksiValidator, NazivIPutanjaValidator nazivIPutanjaValidator)
        {
            Include(indeksiValidator);
           // Include(nazivIPutanjaValidator);
        }
    }
}