using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TwojDentysta.DAL;
using TwojDentysta.Models;

namespace TwojDentysta.Controllers
{
    public class CalendarController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Calendar
        public ActionResult Index(int locationId)
        {
            //DateTime today = DateTime.Today;
            DateTime today = DateTime.Parse("2021-06-21 00:00:00");
            int daysUntilMon = ((int)DayOfWeek.Monday - (int)today.DayOfWeek - 7) % 7;
            int daysUntilSat = ((int)DayOfWeek.Saturday - (int)today.DayOfWeek + 7) % 7;
            DateTime startDate = today.AddDays(daysUntilMon);
            DateTime endDate = today.AddDays(daysUntilSat);
            TimeSpan ts = new TimeSpan(8, 0, 0);
            startDate = startDate.Date + ts;
            endDate = endDate.Date + ts;

            IEnumerable<Appointment> db_appointments = db.Appointments.Where(a => a.Location.ID==locationId)
                .Where(a => startDate < a.Date).Where(a => a.Date < endDate).Where(a => a.Booked==false);

            List<Appointment[]> appointments=new List<Appointment[]>();
            List<DateTime> dates=new List<DateTime>();
            DateTime endtime=startDate.Date + new TimeSpan(18, 0, 0);
            for (var date = startDate; date.Date < endDate.Date; date=date.AddDays(1))
            {
                Appointment[] arr=new Appointment[11];
                int i = 0;
                for(var dtime=date; dtime<endtime; dtime=dtime.AddHours(1))
                {
                    var result = db_appointments.Where(a => a.Date == dtime);
                    if (result.Count() != 0)
                        arr[i] = result.First();
                    else
                        arr[i] = null;
                    i++;
                }
                endtime=endtime.AddDays(1);
                appointments.Add(arr);
                dates.Add(date);
            }

            IEnumerable<Physician> physicians = db.Physicians.ToList();
            string selectedLocationName = db.Locations.Where(l => l.ID == locationId).FirstOrDefault().Name;

            return View(new CalendarViewModel()
            {
                Appointments = appointments,
                Dates = dates,
                Physicians = physicians,
                StartDate = startDate,
                EndDate = endDate,
                SelectedLocationID = locationId,
                SelectedLocationName = selectedLocationName
            });
        }
    }
}