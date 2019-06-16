using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLRI.Entity.Base
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime CreateDate { get; private set; }

        [Required]
        public DateTime LastUpdateDate { get; private set; }

        public void SetDate()
        {
            CreateDate = DateTime.Now;
            LastUpdateDate = DateTime.Now;
        }

        public void SetLastUpdateDate()
        {
            LastUpdateDate = DateTime.Now;
        }

        public void SetCreateDate()
        {
            CreateDate = LastUpdateDate == DateTime.MinValue ? DateTime.Now : LastUpdateDate;
        }
    }
}
