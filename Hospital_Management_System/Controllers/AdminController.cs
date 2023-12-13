using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Controllers
{
    public class AdminController
    {
        AppointmentController appointment = new AppointmentController();
        DoctorController doctor = new DoctorController();
        PatientController patient = new PatientController();
        RoomController room = new RoomController();

        public async Task AdminInit()
        {
            Console.WriteLine("========================================================================");
            Console.WriteLine("============================ HMS Dashboard =============================");
            Console.WriteLine("========================================================================");
            Console.WriteLine("1. Manage Patients");
            Console.WriteLine("2. Manage Doctors");
            Console.WriteLine("3. Manage Rooms");
            Console.WriteLine("4. Manage Appointments");
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
                    await patient.PatientInit();
                    break;
                case 2:
                    await doctor.DoctorInit();
                    break;
                case 3:
                    await room.RoomInit();
                    break;
                case 4:
                    await appointment.AppointmentInit();
                    break;
                default:
                    Console.WriteLine("Invalid Option.Please Try again");
                    await AdminInit();
                    break;
            }
        }
    }
}
