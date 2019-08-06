using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using BLRI.DAL.Interfaces.Animals;
using BLRI.DAL.Repositories.Core;
using BLRI.Entity.Animals;
using BLRI.ViewModel.Animals;
using BLRI.ViewModel.LookUp;

namespace BLRI.DAL.Repositories.Animals
{
    public class AnimalRepository : Repository<Animal>, IAnimalRepository
    {
        public AnimalRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<DropdownViewModel<Guid>> GetAnimalsByCategoryId(int categoryId)
        {
            var enumerableAnimals = Context.Animal.Where(a=>a.CategoryId == categoryId)
                .OrderBy(x=>x.AIdNew).Select 
            (animal=> new DropdownViewModel<Guid>()
                {
                    Id = animal.Id,
                    Name = animal.AIdNew
                }).AsEnumerable();
            return enumerableAnimals;
        }

        public List<AnimalListViewModel> GetAnimalListBy()
        {
            var animalList = from animal in Context.Animal
                join c in Context.AnimalCategory on animal.CategoryId equals c.Id
                join g in Context.Genotype on animal.GenotypeId equals g.Id
                join dam in Context.Animal on animal.DamId equals dam.Id into tempDam
                from d in tempDam.DefaultIfEmpty()
                join sire in Context.Animal on animal.SireId equals sire.Id into tempSire
                from s in tempSire.DefaultIfEmpty()
                select new AnimalListViewModel()
                {
                    Id = animal.Id,
                    AIdNew = animal.AIdNew,
                    AIdOld = animal.AIdOld,
                    BirthDate = animal.BirthDate,
                    CategoryName = c.Name,
                    CategoryId = animal.CategoryId,
                    DamAIdNew = d.AIdNew,
                    SireAIdNew = s.AIdNew,
                    DamParity = animal.DamParity,
                    Generation = animal.Generation,
                    GenotypeName = g.Name,
                    DamId = animal.DamId,
                    Gender = animal.Gender,
                    GenotypeId = animal.GenotypeId,
                    SireId = animal.SireId,
                    Year = animal.Year
                };

            return animalList.ToList();
        }

        public AnimalListViewModel GetAnimalInfoById(Guid id)
        {
            var animalList = from animal in Context.Animal
                join c in Context.AnimalCategory on animal.CategoryId equals c.Id
                join g in Context.Genotype on animal.GenotypeId equals g.Id
                join dam in Context.Animal on animal.DamId equals dam.Id into tempDam
                from d in tempDam.DefaultIfEmpty()
                join sire in Context.Animal on animal.SireId equals sire.Id into tempSire
                from s in tempSire.DefaultIfEmpty()
                select new AnimalListViewModel()
                {
                    Id = animal.Id,
                    AIdNew = animal.AIdNew,
                    AIdOld = animal.AIdOld,
                    BirthDate = animal.BirthDate,
                    CategoryName = c.Name,
                    CategoryId = animal.CategoryId,
                    DamAIdNew = d.AIdNew,
                    SireAIdNew = s.AIdNew,
                    DamParity = animal.DamParity,
                    Generation = animal.Generation,
                    GenotypeName = g.Name,
                    DamId = animal.DamId,
                    Gender = animal.Gender,
                    GenotypeId = animal.GenotypeId,
                    SireId = animal.SireId,
                    Year = animal.Year
                };

            return animalList.FirstOrDefault(a=>a.Id == id);
        }

        public IEnumerable<DropdownViewModel<Guid>> GetDamSireByCategoryId(int categoryId, int genderId)
        {
            var enumerableAnimals = Context.Animal.Where(a => a.CategoryId == categoryId && (int)a.Gender == genderId)
                .OrderBy(x => x.AIdNew).Select
                (animal => new DropdownViewModel<Guid>()
                {
                    Id = animal.Id,
                    Name = animal.AIdNew
                }).AsEnumerable();
            return enumerableAnimals;
        }

        public string GenerateAnimalId(string prefix)
        {
            string newId;
            //TODO: Need to fix code
            var animal = Context.Animal.OrderByDescending(x => x.AIdNew).FirstOrDefault(x => x.AIdNew.ToLower().Contains(prefix.ToLower()));
            if (animal != null)
            {
                string lastId = animal.AIdNew;
                string numberString = lastId.Substring(prefix.Length, 6);

                int id = Convert.ToInt32(numberString) + 1;

                newId = prefix + (id.ToString("000000"));
            }
            else
            {
                newId = prefix + "000001";
            }
            return newId;
        }


        //public string GenerateAutoID(string PrefixString, string TableName, string TableFieldName, int StringLength)
        //{
        //    double ICount;
        //    oDataSet = new DataSet();
        //    oCResult = SQLResult("Select " + TableFieldName + " from " + TableName + " where " + TableFieldName + " like '%" + PrefixString + "%'  order by right(" + TableFieldName + "," + StringLength + ")");
        //    oDataSet = (DataSet)oCResult.Data;
        //    if (oDataSet.Tables[0].Rows.Count > 0)
        //    {
        //        ICount = int.Parse(oDataSet.Tables[0].Rows[oDataSet.Tables[0].Rows.Count - 1][0].ToString().Substring(PrefixString.Length, StringLength)) + 1;
        //        PrefixString = PrefixString + ICount.ToString().PadLeft(StringLength, '0');
        //    }
        //    else
        //    {
        //        ICount = 1;
        //        PrefixString = PrefixString + ICount.ToString().PadLeft(StringLength, '0');
        //    }

        //    return PrefixString;
        //}
    }
}
