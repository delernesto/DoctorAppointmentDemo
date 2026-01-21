using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Data.Repositories;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Service.Interfaces;

namespace MyDoctorAppointment.Service.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService()
        {
            _doctorRepository = new DoctorRepository();
        }

        public Doctor Create(Doctor doctor)
        {
            return _doctorRepository.CreateJson(doctor);
        }

        public bool Delete(int id)
        {
            return _doctorRepository.DeleteJson(id);
        }

        public Doctor? Get(int id)
        {
            return _doctorRepository.GetByIdJson(id);
        }

        public IEnumerable<Doctor> GetAll()
        {
            return _doctorRepository.GetAllJson();
        }

        public Doctor Update(int id, Doctor doctor)
        {
            return _doctorRepository.UpdateJson(id, doctor);
        }
    }
}
