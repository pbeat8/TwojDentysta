using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwojDentysta.Models
{
    public class Appointment
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int PhysiciansID { get; set; }
        public int LocationID { get; set; }
        public bool Booked { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public int PatientPhoneNumber { get; set; }
        public string PatientEmail { get; set; }
        public string Description { get; set; }

        public virtual Location Location { get; set; }
        public virtual Physician Physician { get; set; }

    }
}