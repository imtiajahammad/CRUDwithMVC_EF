using CRUDwithMVC_EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDwithMVC_EF.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDBContext employeeDBContext;
        public EmployeeController()
        {
            this.employeeDBContext = new EmployeeDBContext();
        }
        // GET: Employee
        public ActionResult Index()
        {
            List<Employee> employees = employeeDBContext.Employees.ToList();
            return View(employees);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            Employee employee = employeeDBContext.Employees.Where(emp => emp.Id == id).FirstOrDefault<Employee>();
            return View(employee);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                // TODO: Add insert logic here
                employeeDBContext.Employees.Add(employee);
                employeeDBContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(employee);
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            Employee employee = employeeDBContext.Employees.Where(emp => emp.Id == id).FirstOrDefault<Employee>();
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee employee)
        {
            /*if (ModelState.IsValid)
            {
                UpdateModel(employee);
                employeeDBContext.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(model);*/
            try
            {
                employeeDBContext.Entry(employee).State=System.Data.Entity.EntityState.Modified;
                employeeDBContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(employee);
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            Employee employee = employeeDBContext.Employees.Where(emp => emp.Id == id).FirstOrDefault();
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Employee employee)
        {
            try
            {
                // TODO: Add delete logic here
                Employee empSelected = employeeDBContext.Employees.Where(emp => emp.Id == id).FirstOrDefault();
                employeeDBContext.Employees.Remove(empSelected);
                employeeDBContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(employee);
            }
        }
    }
}
