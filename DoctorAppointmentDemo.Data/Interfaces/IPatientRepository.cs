using MyDoctorAppointment.Domain.Entities;


namespace MyDoctorAppointment.Data.Interfaces
{
    public interface IPatientRepository : IGenericRepositoryJson<Patient>
    {
        // you can add more specific doctor's methods
    }
}
