using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Models
{
    public class Doctor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid DoctorId { get; set; } = Guid.NewGuid();
        public string DoctorName { get; set; } = string.Empty;  
        public string Speciality { get; set;} = string.Empty;
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
