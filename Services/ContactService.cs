using ContactNSPerson;
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
        public void SaveContact(List<ContactPerson> contactPersons)
        {
            
            string json = JsonConvert.SerializeObject(contactPersons, Formatting.Indented);
            try
            {
                if (string.IsNullOrEmpty(json))
                {
                    throw new ArgumentException("No contacts to save.");
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error saving contacts: " + ex.Message);
            }
            _persistanceService.Save(json);
            
        }
        public List<ContactPerson> GetAllContacts()
        {
            string allContacts = _persistanceService.Get();
            return JsonConvert.DeserializeObject<List<ContactPerson>>(allContacts) ?? new List<ContactPerson>();
        }
        public List<ContactPerson> SearchByName(string searchTxt)
        {
            return GetAllContacts().Where(p => p.Name.Contains(searchTxt, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
