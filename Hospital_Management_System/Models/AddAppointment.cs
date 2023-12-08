using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Models
{
    public class AddAppointment
    {
        public Patient Patient { get; set; } = new Patient();
        public Doctor Doctor { get; set; } = new Doctor();
    }
}
