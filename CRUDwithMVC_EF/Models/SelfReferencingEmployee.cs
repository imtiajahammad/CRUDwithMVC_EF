using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDwithMVC_EF.Models
{
    public class SelfReferencingEmployee
    {
        // Scalar properties
        [Key]
        public int EmployeeID { get; set; }
        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; }
        [DisplayName("Manager Name")]
        public int? ManagerID { get; set; }

        // Navigation property
        
        public SelfReferencingEmployee Manager { get; set; }
    }
}