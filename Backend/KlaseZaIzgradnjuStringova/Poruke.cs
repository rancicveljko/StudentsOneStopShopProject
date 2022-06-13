namespace Backend.KlaseZaIzgradnjuStringova
{
    public static class Poruke
    {
        public static string serverskaGreska => "Serverska greška!";
        public static string softverskaGreska => "Softverska greška! Prijavite problem administratoru što pre!";
        public static string poterebnoSePrijaviti => "Za korišćenje ove usluge je potrebno prijaviti se na sistem!";
        public static string pogresnaLozinka => "Pogrešna lozinka!";
        public static string neispravnaNovaLozinka => "Nova lozinka ne sme biti identična staroj!";
        public static string dozvoljeneEkstenzije = "";
        public static string KorisnikPosedujeZabranu(string zabrana) => $"Korisnik poseduje zabranu {zabrana}!";
        public static string MetapodaciMorajuDaSadrze(string naziv) => $"Metapodaci moraju da sadrže neprazno polje \"{naziv}\"";
        public static string PotrebnoProslediti(string naziv) => $"{naziv} se mora proslediti!";
        public static string PotrebnoProsleditiSaUslovom(string naziv, string uslov) => $"{naziv} se mora proslediti {uslov}!";
        public static string Sadrzi(string naziv, string dozvoljeno) => $"Nevalidan format! {naziv} sadrži {dozvoljeno}!";
        public static string NevalidanFormat(string naziv, string format) => $"Nevalidan format! {naziv} je formata {format}!";
        public static string VecPostoji(string naziv, string parametar) => $"{naziv} sa {parametar} već postoji!";
        public static string NePostoji(string naziv, string parametar) => $"{naziv} sa {parametar} ne postoji!";
        public static string ServerskaGreska(string opis) => $"{serverskaGreska} {opis} Pokušajte ponovo ili se obratite adminsitratoru sistema!";
        public static string Mora(string naziv, string uslov) => $"{naziv} mora {uslov}!";
        public static string NeSme(string naziv, string uslov) => $"{naziv} ne sme {uslov}!";
        public static string EnumUValidnomOpsegu(string naziv) => $"{naziv} se mora proslediti u validnom opsegu!";
        public static string KorisnickiNalogJe(string status) => $"Korisnički nalog je {status}!";
        public static string KorisnikVecPoseduje(string zabrana) => $"Korisnik već poseduje zabranu {zabrana}!";
    }
}