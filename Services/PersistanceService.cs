using System.ComponentModel.DataAnnotations;

namespace Services
{
    public class PersistanceService : IPersistanceService
    {
        ISaveService _saveService;
        
        public PersistanceService(string type)
        {
            _saveService = GetService(type);
        }
        public void SaveService(string fileName, string json)
        {
            _saveService.Save(fileName, json);
        }
        public ISaveService GetService(string type)
        {
            if (type == "file")
            {
                return new FileService();
            }
            else if (type == "db")
            {
                return new DBSaveService();
            }
            else
            {
                return new FileService();
            }
        }
    }
    public interface IPersistanceService
    {
        ISaveService GetService(string type);
    }
    public class FileService : ISaveService
    {
        public void Save(string fileName, string json)
        {
            File.WriteAllText(fileName, json);
        }
    }
    public class DBSaveService: ISaveService
    {
        public void Save(string fileName, string json)
        {             
                
        }
    }
    public interface ISaveService
    {
        void Save(string fileName, string json);
    }
}
