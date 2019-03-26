using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;

namespace OfficeBoilerProject.Models
{
    [Table("Persons")]
    public class Person : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [ForeignKey("OfficeId")]
        public int OfficeId { get; set; }
        public Office Office { get; set; }

        public IList<Device> Devices { get; set; }
    }
}
