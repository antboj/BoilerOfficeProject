
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;

namespace OfficeBoilerProject.Models
{
    [Table("Offices")]
    public class Office : Entity
    {
        public string Description { get; set; }
        public IList<Person> Persons { get; set; } = new List<Person>();
    }
}
