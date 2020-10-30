using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRUDwithMVC_EF.Models
{
    // Table Splitting: One database Table two Entity (One to One Relationship)
    [Table("People")]
    public class People
    {
        public int PeopleID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public PeopleContactDetail PeopleContactDetail { get; set; }
    }
}