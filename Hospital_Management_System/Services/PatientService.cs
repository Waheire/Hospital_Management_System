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
    public class PatientService : IPatient
    {
        private readonly AppDbContext _context;

        public PatientService()
        {
            _context = new AppDbContext();
        }
        public async Task<string> AddPatientAsync(AddPatient patient)
        {
            try 
            {
                Patient newPatient = new Patient() 
                {
                    FirstName = patient.FirstName,
                    LastName = patient.LastName,
                    Email = patient.Email,
                };
                 await _context.AddAsync(newPatient);
                await _context.SaveChangesAsync();
                return "Patient Added Successfully";
            } catch 
            {
                return "An error occurred!";
            }
        }

        public async Task<string> DeletePatientAsync(Patient patient)
        {
            try 
            {
                _context.Remove(patient);
                await _context.SaveChangesAsync();
                return "Patient Removed Successfully!";
            } catch 
            {
                return "An Error Occurred!";
            }
        }

        public async Task<Patient> GetPatientByIdAsync(Guid id)
        {
                var patient = await _context.Patients.FirstOrDefaultAsync(p => p.PatientId == id);
                return patient;
        }

        public async Task<List<Patient>> GetPatientsAsync()
        {
            try
            {
                var patients = await _context.Patients.ToListAsync();
                return patients;

            }
            catch 
            {
                return new List<Patient>();
            }
        }

        public async Task<string> UpdatePatientAsync(AddPatient newPatient)
        {
            try
            {
                await _context.AddAsync(newPatient);
                await _context.SaveChangesAsync();
                return "Patient Updated Successfully";
            }
            catch
            {
                return "An error occurred!";
            }
        }
    }
}
