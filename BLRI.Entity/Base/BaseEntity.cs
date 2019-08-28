using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BLRI.Entity.Auth;

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

        [Required]
        public string CreatedByUserId { get; private set; }

        [Required]
        public string UpdatedByUserId { get; set; }

        [ForeignKey("CreatedByUserId")]
        public User CreatedByUser { get; set; }

        [ForeignKey("UpdatedByUserId")]
        public User UpdatedByUser { get; set; }


        public void SetCreateUserId()
        {
            CreatedByUserId = UpdatedByUserId;
        }

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
