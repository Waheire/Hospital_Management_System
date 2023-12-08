using Hospital_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Services.IServices
{
    public interface IPatient
    {
        Task<List<Patient>> GetPatientsAsync();
        Task<Patient> GetPatientByIdAsync(Guid id);
        Task<String> AddPatientAsync(AddPatient patient);
        Task<string> UpdatePatientAsync(AddPatient newPatient);
        Task<string> DeletePatientAsync(Patient patient);
    }
}
