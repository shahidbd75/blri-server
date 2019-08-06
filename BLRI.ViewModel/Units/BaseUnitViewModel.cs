using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLRI.ViewModel.Units
{
    public abstract class BaseUnitViewModel
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public double Value { get; set; }
    }
}
