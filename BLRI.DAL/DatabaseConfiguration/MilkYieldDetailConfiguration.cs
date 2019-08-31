using BLRI.Entity.Animals;
using BLRI.Entity.Task;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BLRI.DAL.DatabaseConfiguration
{
    public class MilkYieldDetailConfiguration:IEntityTypeConfiguration<MilkYieldDetail>
    {
        public void Configure(EntityTypeBuilder<MilkYieldDetail> builder)
        {
            builder.Property(a => a.MilkYieldId).IsRequired();
            builder.Property(a => a.Day).IsRequired();
            builder.Property(a => a.DailyMilkYield).IsRequired();

            builder.HasOne<MilkYield>(s => s.MilkYield)
                .WithMany(a=>a.MilkYieldDetails)
                .HasForeignKey(s => s.MilkYieldId).OnDelete(DeleteBehavior.Cascade);
            
            builder.ToTable("MilkYieldDetail");
        }
    }
}
