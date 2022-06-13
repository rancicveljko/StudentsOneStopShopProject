using Backend.KlaseZaIzgradnjuStringova;
using Backend.KlaseZaRadSaPodacima.DTObjekti.Ulazni.Materijali.Materijal;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Materijali;
using Backend.KlaseZaRadSaPodacima.FluentValidatori.ValidatoriZaPonovnoKoriscenje.Oblasti;
using FluentValidation;

namespace Backend.KlaseZaRadSaPodacima.FluentValidatori.Materijali.Materijal
{
    public class DodavanjeMaterijalaDTOValidator : AbstractValidator<DodavanjeMaterijalaDTO>
    {
        public DodavanjeMaterijalaDTOValidator(PutanjaNazivIEkstenzijaValidator putanjaNazivIEkstenzijaValidator)
        {
            RuleFor(kreiranjeMaterijala => kreiranjeMaterijala.KratakOpis).NotEmpty()
                                                                          .WithMessage(kratakOpis => Poruke.PotrebnoProslediti("Kratak opis"));
        }
    }
}