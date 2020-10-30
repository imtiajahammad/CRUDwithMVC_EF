using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRUDwithMVC_EF.Models
{
    [Table("PeopleContactDetail")]
    // Table Splitting: One database Table two Entity (One to One Relationship)
    public class PeopleContactDetail
    {
        public int PeopleID { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string LandLine { get; set; }
        public People People { get; set; }
    }
}