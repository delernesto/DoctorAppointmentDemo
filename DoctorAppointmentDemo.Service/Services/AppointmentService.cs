using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Data.Repositories;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Service.Interfaces;

namespace MyDoctorAppointment.Service.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService()
        {
            _appointmentRepository = new AppointmentRepository();
        }

        public Appointment Create(Appointment appointment)
        {
            return _appointmentRepository.CreateJson(appointment);
        }

        public bool Delete(int id)
        {
            return _appointmentRepository.DeleteJson(id);
        }

        public Appointment? Get(int id)
        {
            return _appointmentRepository.GetByIdJson(id);
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _appointmentRepository.GetAllJson();
        }

        public Appointment Update(int id, Appointment appointment)
        {
            return _appointmentRepository.UpdateJson(id, appointment);
        }
    }
}
