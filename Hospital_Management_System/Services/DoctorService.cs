using Hospital_Management_System.Data;
using Hospital_Management_System.Models;
using Hospital_Management_System.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Services
{
    public class DoctorService : IDoctor
    {
        private readonly AppDbContext _context;

        public DoctorService()
        {
            _context = new AppDbContext();
        }


        public async Task<string> AddPatientAsync(AddDoctor doctor)
        {
            try 
            {
                Doctor newDoctor = new Doctor() 
                {
                    DoctorName = doctor.DoctorName,
                    Speciality = doctor.Speciality,
                };

                await _context.AddAsync(newDoctor);
                await _context.SaveChangesAsync();
                return "Doctor Successfully Added!";
            } catch 
            {
                return "An error Occurred!";
            }
        }

        public async Task<string> DeleteDoctorAsync(Doctor doctor)
        {
            try 
            {
               _context.Remove(doctor);
                await _context.SaveChangesAsync();
                return "Doctor deleted successfully!";
            } catch 
            {
                return "An error occurred!";
            }
        }

        public async Task<List<Doctor>> GetDoctorsAsync()
        {
            try 
            {
                var doctors = await _context.Doctors.ToListAsync();
                return doctors;
            } catch 
            {
                return new List<Doctor> { };
            }
        }

        public async Task<Doctor> GetDoctortByIdAsync(Guid id)
        {
            try 
            {
                var doctor = await _context.Doctors.FirstOrDefaultAsync(d => d.DoctorId == id);
                return doctor;
            } catch 
            {
                return new Doctor();
            }
           
        }

        public async Task<string> UpdateDoctorAsync(Guid id, AddDoctor newDoctor)
        {
            try 
            {
                var doctor = await _context.Doctors.FirstOrDefaultAsync(d => d.DoctorId == id);
                doctor.DoctorName = newDoctor.DoctorName;
                doctor.Speciality = newDoctor.Speciality;
                _context.Update(doctor);
                await _context.SaveChangesAsync();
                return "Doctor Successfully Updated!";
            } catch 
            {
                return "An error Occurred!";
            }
        }
    }
}
