
using Hospital_Management_System.Controllers;

PatientController patient = new PatientController();
RoomController roomController = new RoomController();
DoctorController doctorController = new DoctorController();
AppointmentController appointmentController = new AppointmentController();

//await patient.PatientInit();
//await roomController.RoomInit();
//await doctorController.DoctorInit();
await appointmentController.AppointmentInit();  