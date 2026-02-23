using System.ComponentModel.DataAnnotations;

namespace Services
{
    public class PersistanceService
    {
        string _type;
        
        public PersistanceService(string type)
        {
            _type = type;
            
        }
        public void SaveToFile(string fileName, string json)
        {
            File.WriteAllText(fileName, json);
        }
    }
}
