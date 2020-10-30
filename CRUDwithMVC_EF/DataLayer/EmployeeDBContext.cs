using CRUDwithMVC_EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUDwithMVC_EF
{
    public class EmployeeDBContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
            // Specify properties to map to Employees table
                .Map(map =>
                {
                map.Properties(p => new
                    {
                        p.PersonId,
                        p.FirstName,
                        p.LastName,
                        p.Gender
                    });

                    map.ToTable("Persons");
                })
            // Specify properties to map to EmployeeContactDetails table
                .Map(map =>
                {
                map.Properties(p => new
                    {
                        p.PersonId,
                        p.Email,
                        p.Mobile,
                        p.Landline
                    });

                    map.ToTable("PersonContactDetails");
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}