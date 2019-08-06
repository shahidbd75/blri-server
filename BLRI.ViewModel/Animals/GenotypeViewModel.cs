using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLRI.ViewModel.Animals
{
    public class GenotypeViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter genotype")]
        public string Name { get; set; }
    }
}
