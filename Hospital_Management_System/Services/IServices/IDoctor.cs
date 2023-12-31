﻿using Hospital_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Services.IServices
{
    internal interface IDoctor
    {
        Task<List<Doctor>> GetDoctorsAsync();
        Task<Doctor> GetDoctortByIdAsync(Guid id);
        Task<String> AddPatientAsync(AddDoctor doctor);
        Task<string> UpdateDoctorAsync(Guid id, AddDoctor newDoctor);
        Task<string> DeleteDoctorAsync(Doctor doctor);
    }
}
