using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCProductAssignment;

namespace MVCProductAssignment.Controllers
{
    public class Customers_TableController : Controller
    {
        private JulyDotNetBatch2020Entities db = new JulyDotNetBatch2020Entities();

        // GET: Customers_Table
        public ActionResult Index()
        {
            var customers_Table = db.Customers_Table.Include(c => c.ProductTable);
            return View(customers_Table.ToList());
        }

        // GET: Customers_Table/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers_Table customers_Table = db.Customers_Table.Find(id);
            if (customers_Table == null)
            {
                return HttpNotFound();
            }
            return View(customers_Table);
        }

        // GET: Customers_Table/Create
        public ActionResult Create()
        {
            ViewBag.proId = new SelectList(db.ProductTables, "proId", "proName");
            return View();
        }

        // POST: Customers_Table/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "customerId,customerName,proId")] Customers_Table customers_Table)
        {
            if (ModelState.IsValid)
            {
                db.Customers_Table.Add(customers_Table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.proId = new SelectList(db.ProductTables, "proId", "proName", customers_Table.proId);
            return View(customers_Table);
        }

        // GET: Customers_Table/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers_Table customers_Table = db.Customers_Table.Find(id);
            if (customers_Table == null)
            {
                return HttpNotFound();
            }
            ViewBag.proId = new SelectList(db.ProductTables, "proId", "proName", customers_Table.proId);
            return View(customers_Table);
        }

        // POST: Customers_Table/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "customerId,customerName,proId")] Customers_Table customers_Table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customers_Table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.proId = new SelectList(db.ProductTables, "proId", "proName", customers_Table.proId);
            return View(customers_Table);
        }

        // GET: Customers_Table/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers_Table customers_Table = db.Customers_Table.Find(id);
            if (customers_Table == null)
            {
                return HttpNotFound();
            }
            return View(customers_Table);
        }

        // POST: Customers_Table/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customers_Table customers_Table = db.Customers_Table.Find(id);
            db.Customers_Table.Remove(customers_Table);
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
