using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;
using Newtonsoft.Json;

namespace MyDoctorAppointment.Data.Repositories
{
    public abstract class GenericRepositoryJson<TSource> : IGenericRepositoryJson<TSource> where TSource : Auditable
    {
        public abstract string Path { get; set; }

        public abstract int LastId { get; set; }

        public TSource CreateJson(TSource source)
        {
            source.Id = ++LastId;
            source.CreatedAt = DateTime.Now;

            File.WriteAllText(Path, JsonConvert.SerializeObject(GetAllJson().Append(source), Formatting.Indented));
            SaveLastId();

            return source;
        }

        public bool DeleteJson(int id)
        {
            if (GetByIdJson(id) is null)
                return false;

            File.WriteAllText(Path, JsonConvert.SerializeObject(GetAllJson().Where(x => x.Id != id), Formatting.Indented));

            return true;
        }

        public IEnumerable<TSource> GetAllJson()
        {
            if (!File.Exists(Path))
            {
                File.WriteAllText(Path, "[]");
            }

            var json = File.ReadAllText(Path);

            if (string.IsNullOrWhiteSpace(json))
            {
                File.WriteAllText(Path, "[]");
                json = "[]";
            }

            return JsonConvert.DeserializeObject<List<TSource>>(json)!;
        }

        public TSource? GetByIdJson(int id)
        {
            return GetAllJson().FirstOrDefault(x => x.Id == id);
        }

        public TSource UpdateJson(int id, TSource source)
        {
            source.UpdatedAt = DateTime.Now;
            source.Id = id;

            File.WriteAllText(Path, JsonConvert.SerializeObject(GetAllJson().Select(x => x.Id == id ? source : x), Formatting.Indented));

            return source;
        }

        public abstract void ShowInfoJson(TSource source);

        protected abstract void SaveLastId();

        protected dynamic ReadFromAppSettings() => JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(Constants.AppSettingsPath))!;
    }
}
