using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;
using BLRI.Entity.Base;

namespace BLRI.Entity
{
    public class Animal: BaseEntity
    {
        public string Code { get; set; }
        public string OldCode { get; set; }

        public DateTime BirthDate { get; set; }

        public string  Gender{ get; set; }

        public string SireId { get; set; }
        public string DamId { get; set; }

        public string GenoType { get; set; }

        public int Generation { get; set; }
        public int DamParity { get; set; }
        public string Session { get; set; }
        public int Year { get; set; }

    }
}
