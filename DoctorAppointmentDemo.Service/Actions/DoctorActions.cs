using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Service.Interfaces;
using MyDoctorAppointment.Service.Services;

namespace MyDoctorAppointment
{
    public class DoctorActions
    {
        private readonly IDoctorService _doctorService;

        public DoctorActions(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        public void AddDoctor()
        {
            Console.WriteLine("Adding doctor: ");

            Console.Write("Enter doctor's first name: ");
            string name = Console.ReadLine();

            Console.Write("Enter doctor's surname: ");
            string surname = Console.ReadLine();

           byte experience;
            while (true)
            {
                Console.Write("Enter doctor's experience (years): ");
                if (byte.TryParse(Console.ReadLine(), out experience) && experience >= 0)
                    break;
                Console.WriteLine("Invalid input. Please enter a positive number.");
            }

            // Type ENUM
            Console.WriteLine("Choose doctor's type:");
            foreach (var type in Enum.GetValues(typeof(Domain.Enums.DoctorTypes)))
            {
                Console.WriteLine($"{(int)type}. {type}");
            }

            Domain.Enums.DoctorTypes doctorType;
            while (true)
            {
                Console.Write("Enter number for doctor's type: ");
                if (Enum.TryParse(Console.ReadLine(), out doctorType) && Enum.IsDefined(typeof(Domain.Enums.DoctorTypes), doctorType))
                    break;
                Console.WriteLine("Invalid choice. Try again.");
            }

            
            var newDoctor = new Doctor
            {
                Name = name,
                Surname = surname,
                Experience = experience,
                DoctorType = doctorType
            };

            _doctorService.Create(newDoctor);

            Console.WriteLine($"Doctor {name} {surname} added successfully!");
        }

        public void ShowDoctors()
        {

            Console.WriteLine("Current doctors list: ");
            var docs = _doctorService.GetAll();

            foreach (var doc in docs)
            {
                Console.WriteLine($"Id: {doc.Id}, Name: {doc.Name} {doc.Surname}");
            }
        }
    }
}