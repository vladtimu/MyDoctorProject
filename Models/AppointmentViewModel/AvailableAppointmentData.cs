using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimuVladProiect.Models.AppointmentViewModel
{
    public class AvailableAppointmentData
    {
        public int ServiceID { get; set; }
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
    }
}
