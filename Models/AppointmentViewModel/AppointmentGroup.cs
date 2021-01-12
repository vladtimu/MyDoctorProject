using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TimuVladProiect.Models.AppointmentViewModel
{
    public class AppointmentGroup
    {
        [DataType(DataType.Date)]
        public DateTime? AppointmentDate { get; set; }
        public int ReservationsCount { get; set; }
    }
}
