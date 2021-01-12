using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimuVladProiect.Models
{
    public class Appointment
    {
        public int ServiceID { get; set; }
        public int UserID { get; set; }
        public int AppointmentID { get; set; }
        public DateTime DataProgramare { get; set; }

        public Service Service { get; set; }
        public User User { get; set; }
    }
}
