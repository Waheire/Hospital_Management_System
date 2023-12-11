using Hospital_Management_System.Data;
using Hospital_Management_System.Models;
using Hospital_Management_System.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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


        public async Task<string> AddAppointmentAsync(AddAppointment appointment)
        {
            try 
            {
                Appointment newAppointment = new Appointment()
                {
                   PatientId = appointment.PatientId,
                   DoctorId   = appointment.DoctorId,
                   AppointmentDate = appointment.AppointmentDate,
                   AppointmentTime = appointment.AppointmentTime,
                };

                await _context.AddAsync(newAppointment);
                await _context.SaveChangesAsync();
                return "Appointment Successfully Added!";
            } catch 
            {
                return "An error occurred!";
            }
        }

        public async Task<string> DeleteAppointmentAsync(Appointment appointment)
        {
            try 
            {
                _context.Remove(appointment);
                await _context.SaveChangesAsync();
                return "Doctor deleted successfully!";
            } catch 
            {
                return "An error occurred!";
            }
        }

        public async Task<Appointment> GetAppointmentByIdAsync(Guid id)
        {
            try 
            {
                var appointment = await _context.Appointments.FirstOrDefaultAsync(x => x.AppointmentId == id);
                return appointment;
            } catch 
            {
                return new Appointment();
            }
        }

        public async Task<List<Appointment>> GetAppointmentsAsync()
        {
            try 
            {
                var appointment = await _context.Appointments.ToListAsync();
                return appointment;
            } catch 
            {
                return new List<Appointment>();
            }
         
        }

        public async  Task<string> UpdateAppointmentAsync(Guid id , AddAppointment newAppointment)
        {
            try
            {
                var appointment = await _context.Appointments.FirstOrDefaultAsync(a => a.AppointmentId == id);
                appointment.PatientId = newAppointment.PatientId;
                appointment.DoctorId = newAppointment.DoctorId;
                appointment.AppointmentDate = newAppointment.AppointmentDate;
                appointment.AppointmentTime = newAppointment.AppointmentTime;
                _context.Update(appointment);
                await _context.SaveChangesAsync();
                return "Appointment Successfully Updated!";
            }
            catch
            {
                return "An error Occurred!";
            }
        }
    }
}
