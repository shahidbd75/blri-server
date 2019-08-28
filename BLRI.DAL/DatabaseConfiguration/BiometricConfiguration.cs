using BLRI.Entity;
using BLRI.Entity.Animals;
using BLRI.Entity.Task;
using BLRI.Entity.Units;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BLRI.DAL.DatabaseConfiguration
{
    public class BiometricConfiguration:IEntityTypeConfiguration<Biometric>
    {
        public void Configure(EntityTypeBuilder<Biometric> builder)
        {
            builder.Property(a => a.AnimalId).IsRequired();
            builder.Property(a => a.BiometricUnitId).IsRequired();
            builder.Property(a => a.BodyLength).IsRequired().HasDefaultValue(0);
            builder.Property(a => a.ChestGirth).IsRequired().HasDefaultValue(0);
            builder.Property(a => a.WitherHeight).IsRequired().HasDefaultValue(0);
            builder.Property(a => a.HipHeight).IsRequired().HasDefaultValue(0);
            builder.Property(a => a.RumpLength).IsRequired().HasDefaultValue(0);
            builder.Property(a => a.RumpWidth).IsRequired().HasDefaultValue(0);
            builder.Property(a => a.HeadLength).IsRequired().HasDefaultValue(0);
            builder.Property(a => a.HeadBreadth).IsRequired().HasDefaultValue(0);
            builder.Property(a => a.NeckLength).IsRequired().HasDefaultValue(0);
            builder.Property(a => a.NeckBreadth).IsRequired().HasDefaultValue(0);
            builder.Property(a => a.EarBreadth).IsRequired().HasDefaultValue(0);
            builder.Property(a => a.EarLength).IsRequired().HasDefaultValue(0);
            builder.Property(a => a.HornLength).IsRequired().HasDefaultValue(0);
            builder.Property(a => a.HornCircumference).IsRequired().HasDefaultValue(0);
            builder.Property(a => a.TailLength).IsRequired().HasDefaultValue(0);
            builder.Property(b => b.TailCircumference).IsRequired().HasDefaultValue(0);
            builder.Property(a => a.LegLengthFront).IsRequired().HasDefaultValue(0);
            builder.Property(a => a.LegLengthHind).IsRequired().HasDefaultValue(0);


            builder.HasOne<Animal>(s => s.Animal)
                .WithMany(a=>a.Biometrics)
                .HasForeignKey(s => s.AnimalId).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<BiometricUnit>(s => s.BiometricUnit)
                .WithMany(a => a.Biometrics)
                .HasForeignKey(s => s.BiometricUnitId).OnDelete(DeleteBehavior.Cascade);


            builder.ToTable("Biometric");
        }
    }
}
