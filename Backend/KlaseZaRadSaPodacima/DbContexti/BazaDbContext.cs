using Backend.KlaseZaRadSaPodacima.Entiteti;
using EntityFramework.Exceptions.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace Backend.KlaseZaRadSaPodacima.DBContexti
{
    public class BazaDbContext : DbContext
    {
        public DbSet<KorisnickiNalogEntitet> KorisnickiNalozi { get; set; }
        public DbSet<KorisnikEntitet> Korisnici { get; set; }
        public DbSet<MaterijalEntitet> Materijali { get; set; }
        public DbSet<OsnovniKorisnikPodaciEntitet> OsnovniKorisnikPodaci { get; set; }
        public DbSet<IstorijaIzmenaEntitet> IstorijaIzmena { get; set; }
        public DbSet<OcenaEntitet> Ocene { get; set; }
        public DbSet<KomentarEntitet> Komentari { get; set; }
        public DbSet<ZahtevAdministratoruEntitet> AdministratorskiZahtevi { get; set; }
        public DbSet<OblastEntitet> Oblasti { get; set; }
        public DbSet<ZahtevZaDodavanjeIliAzuriranjeMaterijalaEntitet> ZahteviZaDodavanjeIliAzuriranjeMaterijala { get; set; }
        public DbSet<KorisnickiNalogOblastEntitet> OblastiINadlezni { get; set; }
        public BazaDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(BazaDbContext).Assembly);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseExceptionProcessor();
        }
    }
}