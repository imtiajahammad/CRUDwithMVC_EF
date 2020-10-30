using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUDwithMVC_EF;
using CRUDwithMVC_EF.Models;

namespace CRUDwithMVC_EF.Controllers
{
    public class SelfReferencingEmployeesController : Controller
    {
        private EmployeeDBContext db = new EmployeeDBContext();

        // GET: SelfReferencingEmployees
        public ActionResult Index()
        {
            var selfReferencingEmployees = db.SelfReferencingEmployees.Include(s => s.Manager);           
            return View(selfReferencingEmployees);
        }

        // GET: SelfReferencingEmployees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SelfReferencingEmployee selfReferencingEmployee = db.SelfReferencingEmployees.Find(id);
            if (selfReferencingEmployee == null)
            {
                return HttpNotFound();
            }
            return View(selfReferencingEmployee);
        }

        // GET: SelfReferencingEmployees/Create
        public ActionResult Create()
        {
            ViewBag.ManagerID = new SelectList(db.SelfReferencingEmployees, "EmployeeID", "EmployeeName");
            return View();
        }

        // POST: SelfReferencingEmployees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,EmployeeName,ManagerID")] SelfReferencingEmployee selfReferencingEmployee)
        {
            if (ModelState.IsValid)
            {
                db.SelfReferencingEmployees.Add(selfReferencingEmployee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ManagerID = new SelectList(db.SelfReferencingEmployees, "EmployeeID", "EmployeeName", selfReferencingEmployee.ManagerID);
            return View(selfReferencingEmployee);
        }

        // GET: SelfReferencingEmployees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SelfReferencingEmployee selfReferencingEmployee = db.SelfReferencingEmployees.Find(id);
            if (selfReferencingEmployee == null)
            {
                return HttpNotFound();
            }
            ViewBag.ManagerID = new SelectList(db.SelfReferencingEmployees, "EmployeeID", "EmployeeName", selfReferencingEmployee.ManagerID);
            return View(selfReferencingEmployee);
        }

        // POST: SelfReferencingEmployees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,EmployeeName,ManagerID")] SelfReferencingEmployee selfReferencingEmployee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(selfReferencingEmployee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ManagerID = new SelectList(db.SelfReferencingEmployees, "EmployeeID", "EmployeeName", selfReferencingEmployee.ManagerID);
            return View(selfReferencingEmployee);
        }

        // GET: SelfReferencingEmployees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SelfReferencingEmployee selfReferencingEmployee = db.SelfReferencingEmployees.Find(id);
            if (selfReferencingEmployee == null)
            {
                return HttpNotFound();
            }
            return View(selfReferencingEmployee);
        }

        // POST: SelfReferencingEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SelfReferencingEmployee selfReferencingEmployee = db.SelfReferencingEmployees.Find(id);
            db.SelfReferencingEmployees.Remove(selfReferencingEmployee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
