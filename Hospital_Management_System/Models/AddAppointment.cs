using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Models
{
    public class AddAppointment
    {
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; } 
        public DateTime AppointmentDate { get; set; } = DateTime.Now;
        public TimeSpan AppointmentTime { get; set; } = TimeSpan.Zero;
    }
}
