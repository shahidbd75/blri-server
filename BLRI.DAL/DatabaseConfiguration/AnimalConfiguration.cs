using BLRI.Entity;
using BLRI.Entity.Animals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BLRI.DAL.DatabaseConfiguration
{
    public class AnimalConfiguration:IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.Property(a => a.AIdNew).IsRequired().IsUnicode(true);
            builder.HasIndex(a => a.AIdOld).IsUnique(true);
            builder.Property(a => a.CategoryId).IsRequired();
            builder.Property(a => a.Gender).IsRequired();
            builder.Property(a => a.Generation).IsRequired();
            builder.Property(a => a.GenotypeId).IsRequired();
            builder.Property(a => a.BirthDate).IsRequired();
            builder.Property(a => a.DamParity).IsRequired();

            builder.HasOne<AnimalCategory>(s => s.AnimalCategory)
                .WithMany(a=>a.Animals)
                .HasForeignKey(s => s.CategoryId).OnDelete(DeleteBehavior.Cascade);


            builder.HasOne<Genotype>(s => s.Genotype)
                .WithMany(a => a.Animals)
                .HasForeignKey(s => s.GenotypeId).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<Animal>(s => s.Dam)
                .WithMany(a => a.DamAnimals)
                .HasForeignKey(s => s.DamId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne<Animal>(s => s.Sire)
                .WithMany(a => a.SireAnimals)
                .HasForeignKey(s => s.SireId).OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Animal");
        }
    }
}
