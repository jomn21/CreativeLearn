using ContactManager.Utility;
using Newtonsoft.Json;

namespace Services
{
    public class ContactService
    {
        IPersistanceService _persistanceService; 
        public ContactService(IPersistanceService persistanceService)
        {
            _persistanceService= persistanceService;
        }
        public void SaveContact(ContactPerson contactPerson)
        {
            
            if(string.IsNullOrEmpty(contactPerson.Name))
            {
                throw new ArgumentException("Name cannot be empty.");
            }

            try
            {
                _persistanceService.Save(contactPerson);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error saving contacts: " + ex.Message);
            }
            
            
        }
        public List<ContactPerson> GetAllContacts()
        {
            return _persistanceService.GetAll();            
        }
        public List<ContactPerson> SearchByName(string searchTxt)
        {
            return GetAllContacts().Where(p => p.Name.Contains(searchTxt, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
