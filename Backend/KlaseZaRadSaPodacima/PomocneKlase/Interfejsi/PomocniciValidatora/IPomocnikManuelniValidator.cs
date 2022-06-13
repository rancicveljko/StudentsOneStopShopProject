using FluentValidation;

namespace Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi.PomocniciValidatora
{
    public interface IPomocnikManuelniValidator
    {
        bool manuelnoValidiraj<TValidacije>(IValidator<TValidacije> validator,
                                            TValidacije zaValidiranje,
                                            out string poruka);
    }
}