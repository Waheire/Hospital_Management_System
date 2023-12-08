using Hospital_Management_System.Data;
using Hospital_Management_System.Models;
using Hospital_Management_System.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Services
{
    public class AppointmentService : IAppointment
    {

        private readonly AppDbContext _context;
        public AppointmentService()
        {
            _context = new AppDbContext();
        }


        public Task<string> AddAppointmentAsyc(AddAppointment appointment)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteAppointmentAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<Appointment> GetAppointmentByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Appointment>> GetAppointmentsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateAppointmentAsync(AddAppointment newAppointment)
        {
            throw new NotImplementedException();
        }
    }
}
