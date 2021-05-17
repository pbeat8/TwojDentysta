using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TwojDentysta.Models;

namespace TwojDentysta.DAL
{
    public class DentistInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            var locations = new List<Location>
            {
            new Location{Name="", ZipCode="12-345", City="Wrocław", Address="", PhoneNumber=516313212, Lat=0, Long=0},
            new Location{Name="", ZipCode="54-321", City="Kraków", Address="", PhoneNumber=514032461, Lat=0, Long=0},
            };

            locations.ForEach(s => context.Locations.Add(s));
            context.SaveChanges();
            var physicians = new List<Physician>
            {
            new Physician{FirstName="Alina", LastName="Abacka", Title="dr", Specialisation="", PhoneNumber=512431654, Email="aabacka@twojdentysta.pl"},
            new Physician{FirstName="Marcin", LastName="Lewandowsky", Title="dr hab.", Specialisation="", PhoneNumber=541005214, Email="mlewandowsky@twojdentysta.pl"},
            new Physician{FirstName="Halina", LastName="Nowacka", Title="dr inż", Specialisation="", PhoneNumber=693421513, Email="hnowacka@twojdentysta.pl"},
            new Physician{FirstName="Maurycy", LastName="Dar", Title="dr", Specialisation="", PhoneNumber=714524098, Email="mdar@twojdentysta.pl"},
            };
            physicians.ForEach(s => context.Physicians.Add(s));
            context.SaveChanges();
            var appointments = new List<Appointment>
            {
            new Appointment{Date=DateTime.Parse("2021-06-21 11:00:00"), PhysiciansID=1, LocationID=2, Booked=false},
            new Appointment{Date=DateTime.Parse("2021-06-21 12:00:00"), PhysiciansID=1, LocationID=2, Booked=true,
                PatientFirstName="Kinga", PatientLastName="Rusin", PatientPhoneNumber=652528321,
                PatientEmail="kingarofficial@gmail.com", Description="Leczenie kanałowe"},
            new Appointment{Date=DateTime.Parse("2021-06-22 9:00:00"), PhysiciansID=1, LocationID=2, Booked=true,
                PatientFirstName="Tomasz", PatientLastName="Karolak", PatientPhoneNumber=726767443,
                PatientEmail="karolakofficial@gmail.com", Description="Przegląd"},
            new Appointment{Date=DateTime.Parse("2021-06-22 13:00:00"), PhysiciansID=2, LocationID=2, Booked=false},
            new Appointment{Date=DateTime.Parse("2021-06-22 14:00:00"), PhysiciansID=2, LocationID=2, Booked=true,
                PatientFirstName="Tamara", PatientLastName="Arciuch", PatientPhoneNumber=513241592,
                PatientEmail="tamara75@op.pl", Description="Wyrywanie zęba"},
            new Appointment{Date=DateTime.Parse("2021-06-25 11:00:00"), PhysiciansID=2, LocationID=2, Booked=false},
            new Appointment{Date=DateTime.Parse("2021-06-25 12:00:00"), PhysiciansID=2, LocationID=2, Booked=false},
            new Appointment{Date=DateTime.Parse("2021-06-25 13:00:00"), PhysiciansID=2, LocationID=2, Booked=false},

            new Appointment{Date=DateTime.Parse("2021-06-21 11:00:00"), PhysiciansID=3, LocationID=1, Booked=false},
            new Appointment{Date=DateTime.Parse("2021-06-21 12:00:00"), PhysiciansID=4, LocationID=1, Booked=true,
                PatientFirstName="Anna", PatientLastName="Dymna", PatientPhoneNumber=725143892,
                PatientEmail="ania.dymna@gmail.com", Description="Leczenie kanałowe"},
            new Appointment{Date=DateTime.Parse("2021-06-22 9:00:00"), PhysiciansID=3, LocationID=1, Booked=true,
                PatientFirstName="Borys", PatientLastName="Szył", PatientPhoneNumber=562123328,
                PatientEmail="uslugikrawieckie@gmail.com", Description="Usuwanie kamienia"},
            new Appointment{Date=DateTime.Parse("2021-06-23 13:00:00"), PhysiciansID=4, LocationID=1, Booked=false},
            };
            appointments.ForEach(s => context.Appointments.Add(s));
            context.SaveChanges();
        }
    }
}