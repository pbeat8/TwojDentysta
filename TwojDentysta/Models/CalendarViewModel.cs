using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwojDentysta.Models
{
    public class CalendarViewModel
    {
        public IEnumerable<Appointment[]> Appointments { get; set; }
        public IEnumerable<DateTime> Dates { get; set; }
        public IEnumerable<Physician> Physicians { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int SelectedPhysicianID { get; set; }
        public int SelectedLocationID { get; set; }
        public string SelectedLocationName { get; set; }

    }
}