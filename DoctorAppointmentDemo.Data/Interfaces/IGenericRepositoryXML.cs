using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Data.Interfaces
{
    public interface IGenericRepositoryXML<TSource> where TSource : Auditable
    {
        TSource CreateXML(TSource source);

        TSource? GetByIdXML(int id);

        TSource UpdateXML(int id, TSource source);

        IEnumerable<TSource> GetAllXML();

        bool DeleteXML(int id);
    }
}
