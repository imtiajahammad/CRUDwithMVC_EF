using CRUDwithMVC_EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUDwithMVC_EF.DataLayer
{
    public class EmployeeDBContextSeeder : DropCreateDatabaseIfModelChanges<EmployeeDBContext>
    {
        protected override void Seed(EmployeeDBContext context)
        {
            Department department = new Department()
            {
                Name = "System Admin",
                Description = "system developers",
                Employees = new List<Employee>()
                {
                    new Employee
                    {
                        FirstName="Imtiaj",
                        LastName="Ahammad",
                        Dob=Convert.ToDateTime("2020-02-12"),
                        Salary=26000,
                        TaxRate=2.3f
                    },
                    new Employee
                    {
                        FirstName="Rafikul",
                        LastName="Karim",
                        Dob=Convert.ToDateTime("2000-02-02"),
                        Salary=56000,
                        TaxRate=1.3f
                    }
                }
            };

            Department department2 = new Department()
            {
                Name = "NGB Admin",
                Description = "client admins",
                Employees = new List<Employee>()
                {
                    new Employee
                    {
                        FirstName="Owain",
                        LastName="Fitzerman",
                        Dob=Convert.ToDateTime("2010-12-01"),
                        Salary=6000,
                        TaxRate=3.3f
                    }
                }
            };
            Person person = new Person()
            {
                FirstName = "testFirstName",
                LastName = "testLastname",
                Gender = "testGender",
                Email = "testEmail",
                Mobile = "testMobile",
                Landline = "testLandline"
            };
            People people= new People()
            {
                FirstName = "testPeopleFirstName",
                LastName = "testPeopleLastName",
                Gender="testPeopleGender",
                PeopleContactDetail = new PeopleContactDetail
                {

                        Email="testPeopleEmail",
                        Mobile="testPeopleMobile",
                        LandLine="testPeopleLandLine"     
                }
            };


            context.Departments.Add(department);
            context.Departments.Add(department2);
            context.Persons.Add(person);
            context.People.Add(people);

            base.Seed(context);
        }
    }
}