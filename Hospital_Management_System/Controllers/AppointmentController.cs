using Hospital_Management_System.Models;
using Hospital_Management_System.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Controllers
{
    public class AppointmentController
    {
        AppointmentService appointmentService = new AppointmentService();
        PatientService patientService = new PatientService();
        DoctorService doctorService = new DoctorService();
        RoomService roomService = new RoomService();

        public async Task AppointmentInit()
        {
            Console.WriteLine("========================================================================");
            Console.WriteLine("============================ Manage Appointments =============================");
            Console.WriteLine("========================================================================");
            Console.WriteLine("1. View Appointments");
            Console.WriteLine("2. Add an Appointment");
            Console.WriteLine("3. Update an Appointment");
            Console.WriteLine("4. Delete an Appointment");
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
                    await ViewAppointments();
                    break;
                case 2:
                    await AddAppointmentView();
                    break;
                case 3:
                    await UpdateAppointmentView();
                    break;
                case 4:
                    await DeleteAppointmentView();
                    break;
                default:
                    Console.WriteLine("Invalid Option.Please Try again");
                    await AppointmentInit();
                    break;
            }
        }

        private async Task DeleteAppointmentView()
        {
            await ViewAppointments();
            Console.WriteLine("===============================================================");
            Console.WriteLine("===================== Delete an Appointment ===================");
            Console.WriteLine("===============================================================");
            Console.WriteLine("Select an Appointment to delete by Id : ");
            var appointmentId = Console.ReadLine();
            Guid AppointmentId;
            Guid.TryParse(appointmentId, out AppointmentId);
            await DeleteDoctor(AppointmentId);
        }

        private async Task DeleteDoctor(Guid appointmentId)
        {
            var appointment = await appointmentService.GetAppointmentByIdAsync(appointmentId);
            if (appointment == null)
            {
                return;
                await AppointmentInit();

            }
            //Delete
            var response = await appointmentService.DeleteAppointmentAsync(appointment);
            Console.WriteLine(response);
            await AppointmentInit();
        }

        private async Task UpdateAppointmentView()
        {
            await ViewAppointments();
            Console.WriteLine("===============================================================");
            Console.WriteLine("===================== Update Appointment ==========================");
            Console.WriteLine("===============================================================");
            Console.WriteLine("Select Appointment to update by Id : ");
            var appointmentId = Console.ReadLine();
            Guid AppointmentId;
            Guid.TryParse(appointmentId, out AppointmentId);
            Console.WriteLine();
            Console.WriteLine("Enter Patient ID: ");
            var patientId = Console.ReadLine();
            var pId = Guid.Parse(patientId);
            Console.WriteLine("Enter Doctor ID: ");
            var doctorId = Console.ReadLine();
            var dId = Guid.Parse(doctorId);
            Console.WriteLine("Enter Date: ");
            var date = Console.ReadLine();
             DateTime dateTime = DateTime.Parse(date);
            Console.WriteLine("Enter Time: ");
            var time = Console.ReadLine();
            TimeSpan timeSpan = TimeSpan.Parse(time);
           var updatedAppointment = new AddAppointment() { PatientId =pId, DoctorId=dId, AppointmentDate = dateTime,  AppointmentTime = timeSpan };
           // await updateAppointment(AppointmentId, updatedAppointment);
        }

        private async Task updateAppointment(Guid id, AddAppointment updatedAppointment)
        {
            var appointment = await appointmentService.GetAppointmentByIdAsync(id);
            if (appointment == null)
            {
                return;
            }
            //Update
            var response = await appointmentService.UpdateAppointmentAsync(id, updatedAppointment);
            Console.WriteLine(response);
            await AppointmentInit();
        }

        private async Task AddAppointmentView()
        {
            Console.WriteLine("===============================================================");
            Console.WriteLine("===================== Add a new Appointment ========================");
            Console.WriteLine("===============================================================");
            Console.WriteLine();
            Console.WriteLine("Enter Patient ID: ");
            var patientId = Console.ReadLine();
            Guid pID = Guid.Parse(patientId);
            Console.WriteLine("Enter Doctor ID: ");
            var doctorId = Console.ReadLine();
            Guid dID = Guid.Parse(doctorId);
            Console.WriteLine("Enter Date: ");
            var date = Console.ReadLine();
            var format = "yyy-MM-dd";
            DateTime dateTime;
            DateTime.TryParseExact(date, format, null, System.Globalization.DateTimeStyles.AllowWhiteSpaces |
                               System.Globalization.DateTimeStyles.AdjustToUniversal, out dateTime);
            Console.WriteLine("Enter Time: ");
            var time = Console.ReadLine();
            var TimeFormat = "HHmmss";
            TimeSpan timeSpan;
            TimeSpan.TryParseExact(time, format, null, out timeSpan);
            //TimeSpan timeSpan = TimeSpan.Parse(time);

            var newAppointment = new AddAppointment() { PatientId = pID, DoctorId = dID, AppointmentDate = dateTime, AppointmentTime= timeSpan};
            await AddAppointment(newAppointment);
        }

        private async Task AddAppointment(AddAppointment newAppointment)
        {

            var response = await appointmentService.AddAppointmentAsync(newAppointment);
            Console.WriteLine(response);
            await AppointmentInit();
        }

        private async Task ViewAppointments()
        {
            var appointments = await appointmentService.GetAppointmentsAsync();
            var doctors = await doctorService.GetDoctorsAsync();
            var patients = await patientService.GetPatientsAsync();
            var rooms = await roomService.GetRoomsAsync();
            var results = from appointment in appointments
                          join doctor in doctors on appointment.DoctorId equals doctor.DoctorId
                          join patient in patients on appointment.PatientId equals patient.PatientId
                          join room in rooms on appointment.PatientId equals room.RoomId
                          select new
                          {
                              AppointmentId = appointment.AppointmentId,
                              Patientname = patient.FirstName + patient.LastName,
                              patientEmail = patient.Email,
                              DoctorAssigned = doctor.DoctorName,
                              DoctorSpeciality = doctor.Speciality,
                              AppointmentDate = appointment.AppointmentDate,
                              AppointmentTime = appointment.AppointmentTime,
                              AssignedRoom = room.RoomNumber

                          };
            Console.WriteLine($"" +
                $"Appointment ID \t\t\t\t Patient Name \t Patient Email  \t Doctor Assigned \t Doctor's Specialty \t Appointment Date \t Appointment Time \t Room Assigned");
            foreach (var appointment in results)
            {
                Console.WriteLine($"{appointment.AppointmentId}  \t {appointment.Patientname} \t {appointment.patientEmail} \t " +
                    $"{appointment.DoctorAssigned} \t {appointment.DoctorSpeciality} \t {appointment.AppointmentDate} \t { appointment.AppointmentTime} \t {appointment.AssignedRoom}"

                    );
            }
        }

        
    }
}
