using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDwithMVC_EF.Models
{
    // Entity Splitting: One Entity two database Table(One to One Relationship)
    public class Person
    {
        // These property values should be stored in Person Table
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }

        // These property values should be stored in PersonContactDetails Table
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Landline { get; set; }
    }
}