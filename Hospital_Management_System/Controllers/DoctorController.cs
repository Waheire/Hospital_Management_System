using Hospital_Management_System.Models;
using Hospital_Management_System.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Controllers
{
    public class DoctorController
    {
        DoctorService doctorService = new DoctorService();


        public async Task DoctorInit()
        {
            Console.WriteLine("========================================================================");
            Console.WriteLine("============================ Manage Doctors =============================");
            Console.WriteLine("========================================================================");
            Console.WriteLine("1. View Doctors");
            Console.WriteLine("2. Add a Doctor");
            Console.WriteLine("3. Update a Doctor");
            Console.WriteLine("4. Delete Doctor");
            Console.Write("Enter your choice: ");
            var choice = Console.ReadLine();
            //convert to int
            var output = int.TryParse(choice, out int option);

            //switch
            await RedirectUser(option);
        }

        public async Task RedirectUser(int option)
        {
            switch (option)
            {
                case 1:
                    await ViewDoctors();
                    break;
                case 2:
                    await AddDoctorView();
                    break;
                case 3:
                    await UpdateDoctorView();
                    break;
                case 4:
                    await DeleteDoctorView();
                    break;
                default:
                    Console.WriteLine("Invalid Option.Please Try again");
                    await DoctorInit();
                    break;
            }
        }

        private async Task DeleteDoctorView()
        {
            await ViewDoctors();
            Console.WriteLine("===============================================================");
            Console.WriteLine("===================== Delete a Doctor ========================");
            Console.WriteLine("===============================================================");
            Console.WriteLine("Select Doctor to delete by Id : ");
            var doctorId = Console.ReadLine();
            Guid DoctorId;
            Guid.TryParse(doctorId, out DoctorId);
            await DeleteDoctor(DoctorId);
        }

        private async Task DeleteDoctor(Guid doctorId)
        {
            var doctor = await doctorService.GetDoctortByIdAsync(doctorId);
            if (doctor == null)
            {
                return;
                await DoctorInit();

            }
            //Delete
            var response = await doctorService.DeleteDoctorAsync(doctor);
            Console.WriteLine(response);
            await DoctorInit();
        }

        private async Task UpdateDoctorView()
        {
            await ViewDoctors();
            Console.WriteLine("===============================================================");
            Console.WriteLine("===================== Update Doctor ==========================");
            Console.WriteLine("===============================================================");
            Console.WriteLine("Select Doctor to update by Id : ");
            var doctorId = Console.ReadLine();
            Guid DoctorId;
            Guid.TryParse(doctorId, out DoctorId);
            Console.WriteLine();
            Console.WriteLine("Enter Doctor's Name: ");
            var doctorName = Console.ReadLine();
            Console.WriteLine("Enter Specialty: ");
            var specialty = Console.ReadLine();

            var updatedDoctor = new AddDoctor() { DoctorName = doctorName, Speciality = specialty };
            await updateDoctor(DoctorId, updatedDoctor);
        }

        public async Task updateDoctor(Guid id, AddDoctor updatedDoctor) 
        {
            var doctor = await doctorService.GetDoctortByIdAsync(id);
            if (doctor == null)
            {
                return;
            }
            //Update
            var response = await doctorService.UpdateDoctorAsync(id, updatedDoctor);
            Console.WriteLine(response);
            await DoctorInit();
        }

        private async Task AddDoctorView()
        {
            Console.WriteLine("===============================================================");
            Console.WriteLine("===================== Add a new Doctor ========================");
            Console.WriteLine("===============================================================");
            Console.WriteLine();
            Console.WriteLine("Enter Doctor's Name: ");
            var doctorName = Console.ReadLine();
            Console.WriteLine("Enter Doctor's Specialty: ");
            var specialty = Console.ReadLine();

            var newDoctor = new AddDoctor() { DoctorName = doctorName, Speciality = specialty };
            await AddDoctor(newDoctor);
        }

        private async Task AddDoctor(AddDoctor newDoctor)
        {
            var response = await doctorService.AddPatientAsync(newDoctor);
            Console.WriteLine(response);
            await DoctorInit();
        }

        private async Task ViewDoctors()
        {
            var doctors = await doctorService.GetDoctorsAsync();
            Console.WriteLine($"Doctor ID \t\t\t\t Doctor Name \t Doctor Specialty ");
            foreach (var doctor in doctors)
            {
                Console.WriteLine($"{doctor.DoctorId}  \t {doctor.DoctorName} \t {doctor.Speciality}");
            }
        }
    }
}
