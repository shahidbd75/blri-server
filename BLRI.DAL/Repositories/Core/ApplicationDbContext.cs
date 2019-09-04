using System.Linq;
using BLRI.DAL.DatabaseConfiguration;
using BLRI.DAL.Extensions;
using BLRI.DAL.Interfaces.Core;
using BLRI.Entity.Animals;
using BLRI.Entity.Auth;
using BLRI.Entity.Task;
using BLRI.Entity.Units;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BLRI.DAL.Repositories.Core
{
    public class ApplicationDbContext: IdentityDbContext<User>, IApplicationDbContext
    {
        public DbSet<BiometricUnit> BiometricUnit { get; set; }
        public DbSet<GrowthUnit> GrowthUnit { get; set; }
        public DbSet<WeightUnit> WeightUnit { get; set; }
        public DbSet<AnimalCategory> AnimalCategory { get; set; }
        public DbSet<Genotype> Genotype { get; set; }
        public DbSet<Animal> Animal { get; set; }
        public DbSet<LiveWeight> LiveWeight { get; set; }
        public DbSet<Biometric> Biometric { get; set; }
        public DbSet<Breeding> Breeding { get; set; }
        public DbSet<Health> Health { get; set; }
        public DbSet<Semen> Semen { get; set; }
        public DbSet<MilkYield> MilkYield { get; set; }
        public DbSet<MilkYieldDetail> MilkYieldDetail { get; set; }
        public DbSet<BreedingService> BreedingServices { get; set; }
        public DbSet<BreedingServiceDetail> BreedingServiceDetails { get; set; }

        public ApplicationDbContext()
        {
            
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnimalConfiguration());
            modelBuilder.ApplyConfiguration(new BiometricConfiguration());
            modelBuilder.ApplyConfiguration(new HealthConfiguration());
            modelBuilder.ApplyConfiguration(new BreedingConfiguration());
            modelBuilder.ApplyConfiguration(new MilkYieldConfiguration());
            modelBuilder.ApplyConfiguration(new MilkYieldDetailConfiguration());
            modelBuilder.ApplyConfiguration(new SemenConfiguration());
            modelBuilder.ApplyConfiguration(new LiveWeightConfiguration());
            modelBuilder.ApplyConfiguration(new BreedingServiceConfiguration());
            modelBuilder.ApplyConfiguration(new BreedingServiceDetailConfiguration());

//            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
//            {
//                relationship.DeleteBehavior = DeleteBehavior.Restrict;
//            }
            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }
    }
}
    