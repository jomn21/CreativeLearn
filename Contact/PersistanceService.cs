using System.ComponentModel.DataAnnotations;

namespace Services
{
    public class PersistanceService
    {
        string _fileName;
        
        public PersistanceService(string fileName)
        {
            _fileName = fileName;
            
        }
        public void SaveToFile(string json)
        {
            File.WriteAllText(_fileName, json);
        }
    }
}
