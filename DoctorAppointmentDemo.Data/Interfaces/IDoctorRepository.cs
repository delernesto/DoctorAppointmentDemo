using MyDoctorAppointment.Domain.Entities;


namespace MyDoctorAppointment.Data.Interfaces
{
    public interface IDoctorRepository : IGenericRepositoryJson<Doctor>
    {
        // you can add more specific doctor's methods
    }
}
