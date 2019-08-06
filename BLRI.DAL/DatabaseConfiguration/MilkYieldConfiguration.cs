using BLRI.Entity;
using BLRI.Entity.Animals;
using BLRI.Entity.Units;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BLRI.DAL.DatabaseConfiguration
{
    public class MilkYieldConfiguration:IEntityTypeConfiguration<MilkYield>
    {
        public void Configure(EntityTypeBuilder<MilkYield> builder)
        {
            builder.Property(a => a.AnimalId).IsRequired();
            builder.Property(a => a.DailyMilkYield).IsRequired();
            builder.Property(a => a.DryPeriod).IsRequired();
            builder.Property(a => a.LactationMilkYield).IsRequired();
            builder.Property(a => a.LactationLength).IsRequired();
            builder.Property(a => a.Persistency).IsRequired();

            builder.HasOne<Animal>(s => s.Animal)
                .WithMany(a=>a.MilkYields)
                .HasForeignKey(s => s.AnimalId).OnDelete(DeleteBehavior.Cascade);
            
            builder.ToTable("MilkYield");
        }
    }
}
