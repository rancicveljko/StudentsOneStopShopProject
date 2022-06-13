using Backend.KlaseZaRadSaPodacima.Entiteti;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.KlaseZaRadSaPodacima.KonfiguracijeEntiteta
{
    public class ZahtevZaDodavanjeIliAzuriranjeMaterijalaEntitetKonfiguracija : IEntityTypeConfiguration<ZahtevZaDodavanjeIliAzuriranjeMaterijalaEntitet>
    {
        public void Configure(EntityTypeBuilder<ZahtevZaDodavanjeIliAzuriranjeMaterijalaEntitet> entitet)
        {
            entitet.HasKey(kljuc => new { kljuc.AutorID, kljuc.MaterijalID, kljuc.VremeSlanja });
            entitet.HasOne<KorisnickiNalogEntitet>(prop => prop.Autor)
                .WithMany(prop => prop.AutorZahtevaZaDodavanjeMaterijala)
                .HasForeignKey(kljuc => kljuc.AutorID);
            entitet.HasOne<MaterijalEntitet>(prop => prop.Materijal)
                .WithMany(prop => prop.SubjekatZahtevaZaDodavanje)
                .HasForeignKey(kljuc => kljuc.MaterijalID);
            entitet.Property(prop => prop.Tekst).IsRequired();
            entitet.Property(prop => prop.TipZahteva).IsRequired();
        }
    }
}