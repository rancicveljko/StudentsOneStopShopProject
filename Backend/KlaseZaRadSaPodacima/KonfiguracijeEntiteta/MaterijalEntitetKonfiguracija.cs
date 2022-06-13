using Backend.KlaseZaRadSaPodacima.Entiteti;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.KlaseZaRadSaPodacima.KonfiguracijeEntiteta
{
    public class MaterijalEntitetKonfiguracija : IEntityTypeConfiguration<MaterijalEntitet>
    {
        public void Configure(EntityTypeBuilder<MaterijalEntitet> entitet)
        {
            entitet.HasKey(kljuc => kljuc.ID);
            entitet.HasOne<OblastEntitet>(prop => prop.Nadoblast)
                .WithMany(prop => prop.Materijali)
                .HasForeignKey(kljuc => kljuc.NadoblastID);
            entitet.Property(prop => prop.ID).ValueGeneratedOnAdd();
            entitet.Property(prop => prop.IDNaFajlSistemu).IsRequired();
            entitet.Property(prop => prop.Status).IsRequired();
            entitet.Property(prop => prop.UkupnaOcena).IsRequired();
            entitet.Property(prop => prop.Ekstenzija).IsRequired();
            entitet.Property(prop => prop.Naziv).IsRequired();
            entitet.Property(prop => prop.KratakOpis).IsRequired();
            entitet.HasIndex(prop => new { prop.NadoblastID, prop.Naziv, prop.Ekstenzija }).IsUnique();
            entitet.HasIndex(prop => prop.IDNaFajlSistemu).IsUnique();
        }
    }
}