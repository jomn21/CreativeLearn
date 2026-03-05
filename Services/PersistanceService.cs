using ContactManager.Infrastructure;
using ContactManager.Utility;
using System.ComponentModel.DataAnnotations;

namespace Services
{
    public interface IPersistanceService
    {
        void Save(ContactPerson contactPerson);
        List<ContactPerson> GetAll();
    }
    public class FilePersistanceService: IPersistanceService
    {
        string _fileName;
        
        public FilePersistanceService(string fileName)
        {
            _fileName = fileName;            
        }
        public void Save(ContactPerson contactPerson)
        {
        }
        public List<ContactPerson> GetAll()
        {
            return new List<ContactPerson>();
        }
    }
    public class DBPersistanceService : IPersistanceService
    {
        string _fileName;
        public DBPersistanceService(string fileName)
        {
            _fileName = fileName;

        }
        public void Save(ContactPerson contactPerson)
        {
            ContactRespository contactRespository = new ContactRespository();
            contactRespository.Save(contactPerson);
        }
        public List<ContactPerson> GetAll()
        {
            
            ContactRespository contactRespository = new ContactRespository();

            return contactRespository.GetAll();
            
        }
    }
}
