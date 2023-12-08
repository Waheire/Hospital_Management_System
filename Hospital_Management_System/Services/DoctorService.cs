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
    public class DoctorService : IDoctor
    {
        private readonly AppDbContext _context;

        public DoctorService()
        {
            _context = new AppDbContext();
        }


        public Task<string> AddPatientAsyc(AddDoctor doctor)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteDoctorAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Doctor>> GetDoctorsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Doctor> GetDoctortByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateDoctorAsync(AddDoctor newDoctor)
        {
            throw new NotImplementedException();
        }
    }
}
