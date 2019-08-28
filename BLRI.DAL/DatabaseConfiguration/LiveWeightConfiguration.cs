using BLRI.Entity;
using BLRI.Entity.Animals;
using BLRI.Entity.Task;
using BLRI.Entity.Units;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BLRI.DAL.DatabaseConfiguration
{
    public class LiveWeightConfiguration:IEntityTypeConfiguration<LiveWeight>
    {
        public void Configure(EntityTypeBuilder<LiveWeight> builder)
        {
            builder.Property(a => a.AnimalId).IsRequired();
            builder.Property(a => a.WeightUnitId).IsRequired();
            builder.Property(a => a.WeightValue).IsRequired();

            builder.HasOne<Animal>(s => s.Animal)
                .WithMany(a=>a.LiveWeights)
                .HasForeignKey(s => s.AnimalId).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<WeightUnit>(s => s.WeightUnit)
                .WithMany(a => a.LiveWeights)
                .HasForeignKey(s => s.WeightUnitId).OnDelete(DeleteBehavior.Cascade);
            builder.ToTable("LiveWeight");
        }
    }
}
