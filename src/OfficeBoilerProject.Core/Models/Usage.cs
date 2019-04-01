using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;

namespace OfficeBoilerProject.Models
{
    [Table("Usages")]
    public class Usage : Entity
    {
        public int Id { get; set; }

        public int PersonId { get; set; }
        [ForeignKey("PersonId")]
        public Person Person { get; set; }

        public int DeviceId { get; set; }
        [ForeignKey("DeviceId")]
        public Device Device { get; set; }

        public DateTime UsedFrom { get; set; }
        public DateTime? UsedTo { get; set; }


    }
}
