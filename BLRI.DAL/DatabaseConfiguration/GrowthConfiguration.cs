using System;
using System.Collections.Generic;
using System.Text;
using BLRI.Entity;
using BLRI.Entity.Animals;
using BLRI.Entity.Units;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BLRI.DAL.DatabaseConfiguration
{
    public class GrowthConfiguration: IEntityTypeConfiguration<Growth>
    {
        public void Configure(EntityTypeBuilder<Growth> builder)
        {
            builder.Property(a => a.AnimalId).IsRequired();
            builder.Property(a => a.GrowthValue).IsRequired();
            builder.Property(a => a.GrowthUnitId).IsRequired();

            builder.HasOne<Animal>(s => s.Animal)
                .WithMany(a => a.Growths)
                .HasForeignKey(s => s.AnimalId).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<GrowthUnit>(s => s.GrowthUnit)
                .WithMany(a => a.Growths)
                .HasForeignKey(s => s.GrowthUnitId).OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Growth");
        }
    }
}
