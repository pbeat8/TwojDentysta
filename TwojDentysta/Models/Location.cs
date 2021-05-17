using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwojDentysta.Models
{
    public class Location
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}