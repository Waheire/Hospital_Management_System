using Hospital_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Services.IServices
{
    internal interface IAppointment
    {
        Task<List<Appointment>> GetAppointmentsAsync();
        Task<Appointment> GetAppointmentByIdAsync(Guid id);
        Task<String> AddAppointmentAsync(AddAppointment appointment);
        Task<string> UpdateAppointmentAsync(Guid id, AddAppointment newAppointment);
        Task<string> DeleteAppointmentAsync(Appointment appointment);
    }
}
