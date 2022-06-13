namespace Backend.KlaseZaRadSaPodacima.PomocneKlase.Interfejsi
{
    public interface IPomocnikKriptovanje
    {
        string KriptujLozinku(string lozinka);
        bool VerifikujLozinku(string lozinka, string lozinkaIzBaze);
    }
}