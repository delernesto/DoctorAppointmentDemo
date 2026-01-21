using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Data.Interfaces
{
    public interface IGenericRepositoryJson<TSource> where TSource : Auditable
    {
        TSource CreateJson(TSource source);

        TSource? GetByIdJson(int id);

        TSource UpdateJson(int id, TSource source);

        IEnumerable<TSource> GetAllJson();

        bool DeleteJson(int id);
    }
}
