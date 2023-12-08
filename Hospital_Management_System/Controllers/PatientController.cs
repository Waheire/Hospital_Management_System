using Hospital_Management_System.Models;
using Hospital_Management_System.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Controllers
{
    public  class PatientController
    {
        PatientService patientService = new PatientService();

        public async Task PatientInit() 
        {
            Console.WriteLine("========================================================================");
            Console.WriteLine("============================ HMS DASHBOARD =============================");
            Console.WriteLine("========================================================================");
            Console.WriteLine("1. View Patients");
            Console.WriteLine("2. Add Patient");
            Console.WriteLine("3. Update Patient");
            Console.WriteLine("4. Delete Patient");
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
                    await ViewPatients();
                    break;
                    case 2:
                    await AddPatientView();
                    break;
                    case 3:
                    await UpdatePatientView();
                    break;
                    case 4:
                    await DeletePatientView();
                    break;
                    default: Console.WriteLine("Invalid Option.Please Try again");
                    await PatientInit();
                    break;
            }
        }

        public async Task UpdatePatientView()
        {
            await ViewPatients();
            Console.WriteLine("===============================================================");
            Console.WriteLine("===================== Update Patient ==========================");
            Console.WriteLine("===============================================================");
            Console.WriteLine("Select Patient to update by Id : ");
            var patientId = Console.ReadLine();
            Guid PatientId;
            Guid.TryParse(patientId, out PatientId);
            Console.WriteLine();
            Console.WriteLine("Enter FirstName: ");
            var FirstName = Console.ReadLine();
            Console.WriteLine("Enter lastName: ");
            var LastName = Console.ReadLine();
            Console.WriteLine("Enter Email: ");
            var Email = Console.ReadLine();

            var updatedPatient = new AddPatient() { FirstName = FirstName, LastName = LastName, Email = Email };
            await UpdatePatient(PatientId, updatedPatient);
        }

        public async Task DeletePatientView()
        {
            await ViewPatients();
            Console.WriteLine("===============================================================");
            Console.WriteLine("===================== Delete Patient ========================");
            Console.WriteLine("===============================================================");
            Console.WriteLine("Select Patient to delete by Id : ");
            var patientId = Console.ReadLine();
            Guid PatientId;
            Guid.TryParse(patientId, out PatientId);
            await DeletePatient(PatientId);
        }

        public async Task AddPatientView()
        {
            Console.WriteLine("===============================================================");
            Console.WriteLine("===================== Add a new Patient ========================");
            Console.WriteLine("===============================================================");
            Console.WriteLine();
            Console.WriteLine("Enter FirstName: ");
            var FirstName = Console.ReadLine();
            Console.WriteLine("Enter lastName: ");
            var LastName = Console.ReadLine();
            Console.WriteLine("Enter Email: ");
            var Email = Console.ReadLine();
           
            var newPatient = new AddPatient() { FirstName = FirstName, LastName = LastName, Email = Email };
            await AddPatient(newPatient);
        }

        public async Task DeletePatient(Guid id)
        {
            var patient = await patientService.GetPatientByIdAsync(id);
            if (patient == null) 
            {
                return;
            }
            //Delete
            var response = await patientService.DeletePatientAsync(patient);
            Console.WriteLine(response);
            await PatientInit();
            
        }

        public async Task UpdatePatient(Guid id, AddPatient updatedPatient)
        {
            var patient = await patientService.GetPatientByIdAsync(id);
            if (patient == null)
            {
                return;
            }
            //Update
            var response = await patientService.UpdatePatientAsync(updatedPatient);
            Console.WriteLine(response);
            await PatientInit();
        }


        public async Task AddPatient(AddPatient newPatient)
        {
            var response = await patientService.AddPatientAsync(newPatient);
            Console.WriteLine(response);
            await PatientInit();
        }

        public async Task ViewPatients()
        {
           var patients = await patientService.GetPatientsAsync();
            Console.WriteLine($"PatientID \t\t\t\t FirstName \t\t\t\t LastName  \t\t\t\t Email \t\t\t\t RoomId ");
            foreach ( var patient in patients ) 
            {
                Console.WriteLine($"{patient.PatientId} \t\t\t\t {patient.FirstName} \t\t\t\t {patient.LastName}  \t\t\t\t {patient.Email} \t\t\t\t {patient.Room.RoomNumber} ");
            }
            await PatientInit();
        }
    }
}
