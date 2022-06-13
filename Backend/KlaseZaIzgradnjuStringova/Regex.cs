namespace Backend.KlaseZaIzgradnjuStringova
{
    public static class Regex
    {
        public static readonly string samoMalaIVelikaSlova = "^[a-zA-Z]+$";
        public static readonly string samoBrojevi = "^[0-9]+$";
        public static readonly string lozinka = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,}$";
        public static readonly string sveDozvoljeno = "(.*?)";
        public static readonly string neprazanString = "^(?!\\s*$).+";
        public static readonly string putanja = "^((/){1}[A-Za-z0-9]+)*(/){1}[a-zA-Z0-9]+$";
        public static readonly string slovaIBrojevi = "^[A-Za-z0-9]+$";
        public static string tipFajla = "";
        public static string nazivSaEkstenzijom = "^[A-Za-z0-9]+(#){1}";
        public static string putanjaNazivIEkstenzija = "^((/){1}[A-Za-z0-9]+)*(/){1}[a-zA-Z0-9]+(#){1}";
        public static string putanjaIEkstenzija = "^((/){1}[A-Za-z0-9]+)*(/){1}[a-zA-Z0-9]+(#){1}";
        public static readonly string putanjaINaziv = "^((/){1}[A-Za-z0-9]+)*(/){1}[a-zA-Z0-9]+(#){1}[A-Za-z0-9]+$";
    }
}