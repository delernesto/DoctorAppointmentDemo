using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Service.Interfaces;
using MyDoctorAppointment.Service.Services;

namespace MyDoctorAppointment
{

    public class DoctorAppointment
    {
        private readonly DoctorActions _doctorActions;
        private readonly PatientActions _patientActions;
        private readonly AppointmentActions _appointmentActions;

        MenuOption _option;

        public DoctorAppointment()
        {
            var doctorService = new DoctorService();
            var patientService = new PatientService();
            var appointmentService = new AppointmentService();

            _doctorActions = new DoctorActions(doctorService);
            _patientActions = new PatientActions(patientService);
            _appointmentActions = new AppointmentActions(appointmentService, doctorService, patientService);
        }

        void Menu_Choice()
        {
            while (true)
            {
                Console.WriteLine("=== Main Menu ===");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Add doctor");
                Console.WriteLine("2. Show doctors");
                Console.WriteLine("3. Add patient");
                Console.WriteLine("4. Show patients");
                Console.WriteLine("5. Add appointment");
                Console.WriteLine("6. Show appointments");

                Console.Write("Choose option: ");
                string ?input = Console.ReadLine();

                if (int.TryParse(input, out int choice) && Enum.IsDefined(typeof(MenuOption), choice))
                {
                    _option = (MenuOption)choice;
                    break; 
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }
        public void Menu()
        {
            while (true)
            {
                Menu_Choice();

                switch (_option)
                {
                    case MenuOption.AddDoctor:
                        _doctorActions.AddDoctor();
                        break;

                    case MenuOption.ShowDoctors:
                        _doctorActions.ShowDoctors();
                        break;

                    case MenuOption.AddPatient:
                        _patientActions.AddPatient();
                        break;

                    case MenuOption.ShowPatients:
                        _patientActions.ShowPatients();
                        break;

                    case MenuOption.AddAppointment:
                        _appointmentActions.AddAppointment();
                        break;

                    case MenuOption.ShowAppointments:
                        _appointmentActions.ShowAppointments();
                        break;

                    case MenuOption.Exit:
                        return;
                }
            }
        }

        public static class Program
        {
            public static void Main()
            {
                var doctorAppointment = new DoctorAppointment();
                doctorAppointment.Menu();
            }
        }
    }
}