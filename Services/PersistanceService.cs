using System.ComponentModel.DataAnnotations;

namespace Services
{
    public interface IPersistanceService
    {
        void Save(string json);
        string Get();
    }
    public class FilePersistanceService: IPersistanceService
    {
        string _fileName;
        
        public FilePersistanceService(string fileName)
        {
            _fileName = fileName;
            
        }
        public void Save(string json)
        {
            File.WriteAllText(_fileName, json);
        }
        public string Get()
        {
            return File.ReadAllText(_fileName);
        }
    }
    public class DBPersistanceService : IPersistanceService
    {
        string _fileName;
        public DBPersistanceService(string fileName)
        {
            _fileName = fileName;

        }
        public void Save(string json)
        {
            File.WriteAllText(_fileName, json);
        }
        public string Get()
        {
            return File.ReadAllText(_fileName);
        }
    }
}
