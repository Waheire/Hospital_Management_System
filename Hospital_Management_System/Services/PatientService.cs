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
                    RoomId = patient.RoomId
             
                };
                 await _context.Patients.AddAsync(newPatient);
                await _context.SaveChangesAsync();
                return "Patient Added Successfully";
            } catch (Exception ex)
            {
                return $"An error occurred! {ex.Message}";
            }
        }

        public async Task<string> DeletePatientAsync(Patient patient)
        {
            try 
            {
                _context.Remove(patient);
                await _context.SaveChangesAsync();
                return "Patient Removed Successfully!";
            } catch (Exception ex)
            {
                return $"An Error Occurred! {ex.Message} ";
            }
        }

        public async Task<Patient> GetPatientByIdAsync(Guid id)
        {
            try 
            {
                var patient = await _context.Patients.FirstOrDefaultAsync(p => p.PatientId == id);
                return patient;
            } catch (Exception ex) 
            {
                return new Patient();
            }
              
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

        public async Task<string> UpdatePatientAsync(Guid id, AddPatient updatedPatient)
        {
            try
            {
                var patient = await _context.Patients.Where(x => x.PatientId == id).FirstOrDefaultAsync();
                patient.FirstName = updatedPatient.FirstName;
                patient.LastName = updatedPatient.LastName;
                patient.Email = updatedPatient.Email;
                _context.Update(patient);
                await _context.SaveChangesAsync();
                return "Patient Updated Successfully";
            }
            catch (Exception ex)
            {
                return $"An error occurred! {ex.Message} ";
            }
        }
    }
}
