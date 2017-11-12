using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimesheetData.Models
{
    public abstract class CommonBaseModel
    {
        [Key, Column(Order = 0)]
        public long Id { get; set; }
        public long? CreatedByUserID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? DeletedByUserID { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public long? LastModifiedByUserID { get; set; }
        [Timestamp]
        public Byte[] RowVersion { get; set; }
    }
}
