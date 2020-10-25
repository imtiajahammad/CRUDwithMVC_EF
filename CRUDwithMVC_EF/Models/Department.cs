using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRUDwithMVC_EF.Models
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public int Id { get; set; }
        //[Display(Name="Department Name")]
        [DisplayName("Department Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}