using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLRI.Entity.Animals
{
    public class AnimalCategory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Animal> Animals { get; set; }
    }
}
