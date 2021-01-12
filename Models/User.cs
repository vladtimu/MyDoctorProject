using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace TimuVladProiect.Models
{
    public class User
    {
      
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int UserID { get; set; }
            public string Name { get; set; }
            public string Adress { get; set; }
            public DateTime BirthDate { get; set; }
            public ICollection<Appointment> Appointments { get; set; }

        
    }
}
