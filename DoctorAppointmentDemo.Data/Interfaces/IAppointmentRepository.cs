using MyDoctorAppointment.Domain.Entities;


namespace MyDoctorAppointment.Data.Interfaces
{
    public interface IAppointmentRepository : IGenericRepositoryJson<Appointment>
    {
        
        // you can add more specific appointment's methods
    }
}
