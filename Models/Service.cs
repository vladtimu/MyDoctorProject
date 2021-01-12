using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimuVladProiect.Models
{
    public class Service
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<DoctorService> DoctorServices { get; set; }
    }

    public class DoctorService
    {
        public int DoctorID { get; set; }
        public int ServiceID { get; set; }
        public Doctor Doctor { get; set; }
        public Service Service { get; set; }
    }
}
