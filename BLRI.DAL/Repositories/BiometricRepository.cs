using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLRI.DAL.Interfaces;
using BLRI.DAL.Repositories.Core;
using BLRI.Entity;
using BLRI.ViewModel.Biometric;

namespace BLRI.DAL.Repositories
{
    public class BiometricRepository : Repository<Biometric>, IBiometricRepository
    {
        public BiometricRepository(ApplicationDbContext context) : base(context)
        {
        }

        public List<BiometricViewModel> GetBiometricByAnimalId(Guid animalId)
        {
            var biometrics = from b in Context.Biometric
                join bu in Context.BiometricUnit on b.BiometricUnitId equals bu.Id
                join a in Context.Animal on b.AnimalId equals a.Id
                where b.AnimalId == animalId
                select new BiometricViewModel()
                {
                    Id = b.Id,
                    AnimalId = b.AnimalId,
                    BiometricUnitId = b.BiometricUnitId,
                    RumpLength = b.RumpLength,
                    LegLengthFront = b.LegLengthFront,
                    RumpWidth = b.RumpWidth,
                    TestesBreadth = b.TestesBreadth,
                    LegLengthHind = b.LegLengthHind,
                    HeadBreadth = b.HeadBreadth,
                    HornLength = b.HornLength,
                    EarLength = b.EarLength,
                    HeadLength = b.HeadLength,
                    HornCircumference = b.HornCircumference,
                    EarBreadth = b.EarBreadth,
                    TailLength = b.TailLength,
                    ChestGirth = b.ChestGirth,
                    NeckBreadth = b.NeckBreadth,
                    NeckLength = b.NeckLength,
                    WitherHeight = b.WitherHeight,
                    TestesCircumference = b.TestesCircumference,
                    TeatCircumference = b.TeatCircumference,
                    HipHeight = b.HipHeight,
                    TeatLength = b.TeatLength,
                    UdderLength = b.UdderLength,
                    UdderBreadth = b.UdderBreadth,
                    BodyLength = b.BodyLength,
                    UdderCircumference = b.UdderCircumference,
                    TestesLength = b.TestesLength,
                    TeatBreadth = b.TeatBreadth,
                    AnimalNewId = a.AIdNew,
                    BiometricUnitName = bu.Name,
                    TailCircumference = b.TailCircumference
                };
            return biometrics.ToList();
        }

        public BiometricViewModel GetBiometricId(Guid id)
        {
            var biometric = from b in Context.Biometric
                join bu in Context.BiometricUnit on b.BiometricUnitId equals bu.Id
                join a in Context.Animal on b.AnimalId equals a.Id
                where b.Id == id
                select new BiometricViewModel()
                {
                    Id = b.Id,
                    AnimalId = b.AnimalId,
                    BiometricUnitId = b.BiometricUnitId,
                    RumpLength = b.RumpLength,
                    LegLengthFront = b.LegLengthFront,
                    RumpWidth = b.RumpWidth,
                    TestesBreadth = b.TestesBreadth,
                    LegLengthHind = b.LegLengthHind,
                    HeadBreadth = b.HeadBreadth,
                    HornLength = b.HornLength,
                    EarLength = b.EarLength,
                    HeadLength = b.HeadLength,
                    HornCircumference = b.HornCircumference,
                    EarBreadth = b.EarBreadth,
                    TailLength = b.TailLength,
                    ChestGirth = b.ChestGirth,
                    NeckBreadth = b.NeckBreadth,
                    NeckLength = b.NeckLength,
                    WitherHeight = b.WitherHeight,
                    TestesCircumference = b.TestesCircumference,
                    TeatCircumference = b.TeatCircumference,
                    HipHeight = b.HipHeight,
                    TeatLength = b.TeatLength,
                    UdderLength = b.UdderLength,
                    UdderBreadth = b.UdderBreadth,
                    BodyLength = b.BodyLength,
                    UdderCircumference = b.UdderCircumference,
                    TestesLength = b.TestesLength,
                    TeatBreadth = b.TeatBreadth,
                    AnimalNewId = a.AIdNew,
                    BiometricUnitName = bu.Name,
                    TailCircumference = b.TailCircumference,
                    AnimalCategoryId = a.CategoryId
                };
            return biometric.FirstOrDefault();
        }
    }
}
