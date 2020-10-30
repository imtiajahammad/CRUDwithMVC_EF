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
        public DbSet<People> People { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /*conditional mapping-start
            modelBuilder.Entity<Employee>()
               .Map(m => m.Requires("IsPermanent")
               .HasValue(true)
               )
               .Ignore(m => m.IsPermanent);
               */

            /*modelBuilder.Entity<Employee>()
                    .Property(p => p.IsPermanent)
                    .HasColumnName("IsPermanent")
                    .HasColumnType("bool");*/


            /*modelBuilder.Entity<Employee>()
                .Ignore(m => m.IsPermanent);*/


            /*conditional mapping-end*/






            //Table Splitting-start
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
            //Table Splitting-end



            //Entity Splitting-start
            modelBuilder.Entity<People>()
                .HasKey(pk => pk.PeopleID)
                .ToTable("People");

            modelBuilder.Entity<PeopleContactDetail>()
                .HasKey(pk => pk.PeopleID)
                .ToTable("People");

            modelBuilder.Entity<People>()
                .HasRequired(p => p.PeopleContactDetail)
                .WithRequiredPrincipal(c => c.People);
            //Entity Splitting-end






            



            base.OnModelCreating(modelBuilder);
        }
    }
}