using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TimuVladProiect.Models
{
    public class Doctor
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Doctor Name")]
        [StringLength(50)]
        public string DoctorName { get; set; }

        [StringLength(70)]
       /* public string Adress { get; set; }*/
        public ICollection<DoctorService> DoctorServices { get; set; }
    }
}
