using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Domain.Enums;
using MyDoctorAppointment.Service.Interfaces;

namespace MyDoctorAppointment
{
    public class PatientActions
    {
        private readonly IPatientService _patientService;

        public PatientActions(IPatientService patientService)
        {
            _patientService = patientService;
        }

        public void AddPatient()
        {
            Console.WriteLine("=== Adding a new patient ===");

            Console.Write("Enter patient's first name: ");
            string name = Console.ReadLine();

            Console.Write("Enter patient's surname: ");
            string surname = Console.ReadLine();

            Console.WriteLine("Choose patient's illness type:");
            foreach (var type in Enum.GetValues(typeof(Domain.Enums.IllnessTypes)))
            {
                Console.WriteLine($"{(int)type}. {type}");
            }

            Domain.Enums.IllnessTypes illnessTypes;
            while (true)
            {
                Console.Write("Enter number for patient's illness type: ");
                if (Enum.TryParse(Console.ReadLine(), out illnessTypes) && Enum.IsDefined(typeof(Domain.Enums.IllnessTypes), illnessTypes))
                    break;
                Console.WriteLine("Invalid choice. Try again.");
            }

            var newPatient = new Patient
            {
                Name = name,
                Surname = surname,
                IllnessType = illnessTypes
            };

            _patientService.Create(newPatient);

            Console.WriteLine($"Patient {name} {surname} added successfully!");
        }

        public void ShowPatients()
        {
            Console.WriteLine("Current patients list: ");
            var patients = _patientService.GetAll();

            foreach (var p in patients)
            {
                Console.WriteLine($"Name: {p.Name} {p.Surname}, Age: {p.IllnessType}");
            }
        }
    }
}