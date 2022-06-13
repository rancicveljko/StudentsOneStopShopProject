using Backend.KlaseZaRadSaPodacima.Entiteti;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.KlaseZaRadSaPodacima.KonfiguracijeEntiteta
{
    public class KomentarEntitetKonfiguracija : IEntityTypeConfiguration<KomentarEntitet>
    {
        public void Configure(EntityTypeBuilder<KomentarEntitet> entitet)
        {
            entitet.HasKey(kljuc => new { kljuc.AutorID, kljuc.MaterijalID, kljuc.VremeKomentarisanja });
            entitet.HasOne<KorisnickiNalogEntitet>(prop => prop.Autor)
                .WithMany(prop => prop.Komentari)
                .HasForeignKey(kljuc => kljuc.AutorID);
            entitet.HasOne<MaterijalEntitet>(prop => prop.Materijal)
                .WithMany(prop => prop.Komentari)
                .HasForeignKey(kljuc => kljuc.MaterijalID);
            entitet.Property(prop => prop.Tekst).IsRequired();
            entitet.Property(prop => prop.VremeKomentarisanja).IsRequired();
            entitet.HasOne<KomentarEntitet>(prop => prop.OdgovorNa)
                   .WithMany(prop => prop.Odgovori);
        }
    }
}