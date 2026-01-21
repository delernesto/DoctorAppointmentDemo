using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;
using System.Xml;
using System.Xml.Linq;

namespace DoctorAppointmentDemo.Data.Repositories
{
    public abstract class GenericRepositoryXML<TSource> : IGenericRepositoryXML<TSource> where TSource : Auditable
    {
        public abstract string Path { get; set; }

        public abstract int LastId { get; set; }
        public TSource CreateXML(TSource source)
        {
            throw new NotImplementedException();
        }

        public bool DeleteXML(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TSource> GetAllXML()
        {
            throw new NotImplementedException();
        }

        public TSource? GetByIdXML(int id)
        {
            throw new NotImplementedException();
        }

        public TSource UpdateXML(int id, TSource source)
        {
            throw new NotImplementedException();
        }
    }
}
