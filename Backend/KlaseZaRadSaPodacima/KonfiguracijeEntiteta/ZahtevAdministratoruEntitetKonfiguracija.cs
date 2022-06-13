using Backend.KlaseZaRadSaPodacima.Entiteti;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.KlaseZaRadSaPodacima.KonfiguracijeEntiteta
{
    public class ZahtevAdministratoruEntitetKonfiguracija : IEntityTypeConfiguration<ZahtevAdministratoruEntitet>
    {
        public void Configure(EntityTypeBuilder<ZahtevAdministratoruEntitet> entitet)
        {
            entitet.HasKey(kljuc => new { kljuc.AutorID, kljuc.VremeSlanja });
            entitet.HasOne<KorisnickiNalogEntitet>(prop => prop.Autor)
                   .WithMany(prop => prop.AutorAdministratorskogZahteva)
                   .HasForeignKey(kljuc =>  kljuc.AutorID )
                   .OnDelete(DeleteBehavior.Restrict);
            entitet.HasOne<KorisnickiNalogEntitet>(prop => prop.Subjekat)
                   .WithMany(prop => prop.SubjekatAdministratorskogZahteva)
                   .HasForeignKey(kljuc => kljuc.SubjekatID )
                   .OnDelete(DeleteBehavior.Restrict);
            entitet.Property(prop => prop.Tip).IsRequired();
            entitet.Property(prop => prop.Tekst).IsRequired();
        }
    }
}