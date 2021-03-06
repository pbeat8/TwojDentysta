using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TwojDentysta.DAL;
using TwojDentysta.Models;
using System.Globalization;

namespace TwojDentysta.Controllers
{
    public class AppointmentsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        public ActionResult PatientData(int id)
        {
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocationID = new SelectList(db.Locations, "ID", "Name", appointment.LocationID);
            return View(appointment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PatientData([Bind(Include = "ID,Date,PhysiciansID,LocationID,Booked,PatientFirstName,PatientLastName,PatientPhoneNumber,PatientEmail,Description")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("ConfirmData", appointment);
            }
            ViewBag.LocationID = new SelectList(db.Locations, "ID", "Name", appointment.LocationID);
            return View(appointment);
        }

        public ActionResult ConfirmData(Appointment appointment)
        {
            Physician physician = db.Physicians.Find(appointment.PhysiciansID);
            Location location = db.Locations.Find(appointment.LocationID);
            ViewBag.Physician = physician.FirstName + " " + physician.LastName;
            ViewBag.Location = location.City + ", " + location.Address;
            return View(appointment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmedData([Bind(Include = "ID,Date,PhysiciansID,LocationID,Booked,PatientFirstName,PatientLastName,PatientPhoneNumber,PatientEmail,Description")] Appointment appointment)
        {
            //to mamy 06/23/2021 14:00:00
            appointment.Date = DateTime.Parse(appointment.Date.ToString("yyyy-MM-dd HH:mm:ss"));
            if (ModelState.IsValid)
            {
                appointment.Booked = true;
                db.Appointments.Add(appointment);
                db.SaveChanges();
                return View();
            }

            return View();
        }

        public ActionResult ConfirmedData()
        {
             return View();
        }

        // GET: Appointments
        //[Authorize]
        public ActionResult Index()
        {
            var appointments = db.Appointments.Include(a => a.Location);
            return View(appointments.ToList());
        }

        // GET: Appointments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // GET: Appointments/Create
        public ActionResult Create()
        {
            ViewBag.LocationID = new SelectList(db.Locations, "ID", "Name");
            return View();
        }

        // POST: Appointments/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Date,PhysiciansID,LocationID,Booked,PatientFirstName,PatientLastName,PatientPhoneNumber,PatientEmail,Description")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Appointments.Add(appointment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LocationID = new SelectList(db.Locations, "ID", "Name", appointment.LocationID);
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocationID = new SelectList(db.Locations, "ID", "Name", appointment.LocationID);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Date,PhysiciansID,LocationID,Booked,PatientFirstName,PatientLastName,PatientPhoneNumber,PatientEmail,Description")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocationID = new SelectList(db.Locations, "ID", "Name", appointment.LocationID);
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Appointment appointment = db.Appointments.Find(id);
            db.Appointments.Remove(appointment);
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
