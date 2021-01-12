using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimuVladProiect.Models;

namespace TimuVladProiect.Data
{
    public class DbInitializer
    {
        public static void Initialize(ServiceContext context)
        {
            context.Database.EnsureCreated();
            if (context.Services.Any())
            {
                return; // BD a fost creata anterior
            }
            var services = new Service[]
            {
            new Service{Name="Implant dentar",Description="Protezele pe implant dentar reprezinta o solutie potrivita de inlocuire a dintilor.",Price=Decimal.Parse("1500")},
            new Service{Name="Aparat dentar",Description="Ortodontia este ramura din stomatologie care se ocupa cu indreptarea dintilor aflati in pozitii vicioase sau inestetice.",Price=Decimal.Parse("2500")},
            new Service{Name="Extractie dentara",Description="Uneori, cand pacientii ajung prea tarziu la stomatolog, dintele nu mai poate fi salvat si este necesara extractia lui si inlocuirea cu un implant dentar.",Price=Decimal.Parse("270")}
            };
            foreach (Service s in services)
            {
                context.Services.Add(s);
            };
            context.SaveChanges();
            var users = new User[]
            {

            new User{UserID=1, Name="Pop Ion", Adress="str. Principala, nr 23443",BirthDate=DateTime.Parse("1979-09-01")},
            new User{UserID=2, Name="Ionescu Adrian", Adress="Blv. Republicii, nr 21, bl. A",BirthDate=DateTime.Parse("2000-07-08")},
            new User{UserID=3, Name="Morariu Bogdan", Adress="Calea Victoriei, nr 2121, bl. B, sc. A",BirthDate=DateTime.Parse("2000-07-08")}

            };
            foreach (User u in users)
            {
                context.Users.Add(u);
            };
            context.SaveChanges();
            var appointment = new Appointment[]
            {
            new Appointment{ServiceID=1,UserID=1, DataProgramare=DateTime.Parse("02-25-2020")},
            new Appointment{ServiceID=3,UserID=2,  DataProgramare=DateTime.Parse("02-25-2019")},
            new Appointment{ServiceID=2,UserID=3, DataProgramare=DateTime.Parse("01-15-2020")},
            new Appointment{ServiceID=1,UserID=1, DataProgramare=DateTime.Parse("03-25-2020")},
             new Appointment{ServiceID=2,UserID=2, DataProgramare=DateTime.Parse("10-25-2020")},
             new Appointment{ServiceID=1,UserID=3, DataProgramare=DateTime.Parse("10-15-2020")},
            };
            foreach (Appointment a in appointment)
            {
                context.Appointments.Add(a);
            };
            context.SaveChanges();
            var doctors = new Doctor[]

 {          new Doctor{DoctorName="Dr. Jon"},
            new Doctor{DoctorName="Dr. Ann"},
            new Doctor{DoctorName="Dr. Michael"},
             new Doctor{DoctorName="Dr. Vlad"},
 };
            foreach (Doctor d in doctors)
            {
                context.Doctors.Add(d);
            }
            context.SaveChanges();
            var doctorService = new DoctorService[]
 {
             new DoctorService { DoctorID = doctors.Single(c => c.DoctorName == "Dr. Jon").ID, ServiceID = services.Single(i => i.Name == "Implant dentar").ID
 },
            new DoctorService { DoctorID = doctors.Single(c => c.DoctorName == "Dr. Ann").ID, ServiceID = services.Single(i => i.Name == "Implant dentar").ID
 },
            new DoctorService { DoctorID = doctors.Single(c => c.DoctorName == "Dr. Vlad").ID, ServiceID = services.Single(i => i.Name == "Aparat dentar").ID
 },
            new DoctorService { DoctorID = doctors.Single(c => c.DoctorName == "Dr. Vlad").ID, ServiceID = services.Single(i => i.Name == "Extractie dentara").ID
 },
            new DoctorService { DoctorID = doctors.Single(c => c.DoctorName == "Dr. Ann").ID, ServiceID = services.Single(i => i.Name == "Aparat dentar").ID
 },
             new DoctorService { DoctorID = doctors.Single(c => c.DoctorName == "Dr. Michael").ID, ServiceID = services.Single(i => i.Name == "Extractie dentara").ID
 },
 };
            foreach (DoctorService ds in doctorService)
            {
                context.DoctorServices.Add(ds);
            }
            context.SaveChanges();
        }
    }
}
    

