using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Service.Interfaces;
using MyDoctorAppointment.Service.Services;

namespace MyDoctorAppointment
{
    public class AppointmentActions
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;

      

        public AppointmentActions(IAppointmentService appointmentService, IDoctorService doctorService, IPatientService patientService)
        {
            _appointmentService = appointmentService;
            _doctorService = doctorService;
            _patientService = patientService;
        }

        public void AddAppointment()
        {
            Console.WriteLine("=== Adding a new appointment ===");

            
            Console.WriteLine("Select a doctor:");
            var doctors = _doctorService.GetAll();
            var docs = _doctorService.GetAll();

            foreach (var doc in docs)
            {
                Console.WriteLine($"Id: {doc.Id}, Name: {doc.Name} {doc.Surname}");
            }

            Doctor doctor;
            while (true)
            {
                Console.Write("Enter the doctor's ID: ");
                if (int.TryParse(Console.ReadLine(), out int doctorId))
                {
                    doctor = doctors.FirstOrDefault(d => d.Id == doctorId);
                    if (doctor != null)
                        break;
                }
                Console.WriteLine("Invalid ID. Try again.");
            }

            // Вибір пацієнта
            Console.WriteLine("Select a patient:");
            var patients = _patientService.GetAll();

            // Виводимо список пацієнтів із Id
            foreach (var p in patients)
            {
                Console.WriteLine($"Id: {p.Id}, Name: {p.Name} {p.Surname}");
            }

            Patient patient;
            while (true)
            {
                Console.Write("Enter the patient's ID: ");
                if (int.TryParse(Console.ReadLine(), out int patientId))
                {
                    // Знаходимо пацієнта з потрібним Id
                    patient = patients.FirstOrDefault(p => p.Id == patientId);
                    if (patient != null)
                        break;
                }
                Console.WriteLine("Invalid ID. Try again.");
            }

            // Дата та час
            DateTime appointmentDate;
            while (true)
            {
                Console.Write("Enter appointment date and time (yyyy-MM-dd HH:mm): ");
                if (DateTime.TryParse(Console.ReadLine(), out appointmentDate))
                    break;
                Console.WriteLine("Invalid date/time format. Try again.");
            }

            var newAppointment = new Appointment
            {
                Doctor = doctor,
                Patient = patient,
                DateTimeFrom = appointmentDate
            };

            _appointmentService.Create(newAppointment);

            Console.WriteLine($"Appointment added successfully for {patient.Name} with Dr. {doctor.Name} on {appointmentDate}.");
        }

        public void ShowAppointments()
        {
            Console.WriteLine("Current appointments list: ");
            var appointments = _appointmentService.GetAll();

            foreach (var a in appointments)
            {
                Console.WriteLine($"{a.DateTimeFrom}: {a.Patient.Name} {a.Patient.Surname} with Dr. {a.Doctor.Name} {a.Doctor.Surname}");
            }
        }
    }
}
