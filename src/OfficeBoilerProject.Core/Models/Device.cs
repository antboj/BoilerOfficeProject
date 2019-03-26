using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;

namespace OfficeBoilerProject.Models
{
    [Table("Devices")]
    public class Device : Entity
    {
        public string Name { get; set; }

        public int? PersonId { get; set; }
        [ForeignKey("PersonId")]
        public Person Person { get; set; }
    }
}
