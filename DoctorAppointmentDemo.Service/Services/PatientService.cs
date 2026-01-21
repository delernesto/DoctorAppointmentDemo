using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Data.Repositories;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Service.Interfaces;

namespace MyDoctorAppointment.Service.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService()
        {
            _patientRepository = new PatientRepository();
        }

        public Patient Create(Patient patient)
        {
            return _patientRepository.CreateJson(patient);
        }

        public bool Delete(int id)
        {
            return _patientRepository.DeleteJson(id);
        }

        public Patient? Get(int id)
        {
            return _patientRepository.GetByIdJson(id);
        }

        public IEnumerable<Patient> GetAll()
        {
            return _patientRepository.GetAllJson();
        }

        public Patient Update(int id, Patient patient)
        {
            return _patientRepository.UpdateJson(id, patient);
        }
    }
}
