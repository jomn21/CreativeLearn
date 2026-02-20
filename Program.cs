//using System.Text.Json;
using ContactNS;
using ContactNSPerson;
using Newtonsoft.Json;
using System.Data;
using Services;

Contact ct = new Contact();
while (true)
{
    ct.Operations();
}

namespace ContactNS
{
    public interface IContact
    {
        void AddContact();
        void Search();
        void Operations();
    }
    public class Contact : IContact
    {
        string fileName = "contactPerson.json";
        List<ContactPerson> contactPersons = new List<ContactPerson>();

        
        public void AddContact()
        {
            {
                ContactPerson contactPerson = new ContactPerson();

                Console.WriteLine("Enter Contact Name");
                contactPerson.Name = Console.ReadLine() ?? string.Empty;

                Console.WriteLine("Enter Age");
                contactPerson.Age = Console.ReadLine() ?? string.Empty;

                Console.WriteLine("Enter Country");
                contactPerson.Country = Console.ReadLine() ?? string.Empty;

                Console.WriteLine("Enter Phone");
                contactPerson.Phone = Console.ReadLine() ?? string.Empty;

                List<ContactPerson> contactPersons = GetAll();

                contactPersons.Add(contactPerson);

                string json = JsonConvert.SerializeObject(contactPersons, Formatting.Indented);

                ContactService contactService = new ContactService(new PersistanceService("file"));
                contactService.SaveContact(fileName, json);
            }
        }

        public void Search()
        {
            Console.WriteLine("Enter name to search..");

            string searchTxt = Console.ReadLine() ?? string.Empty;

            var results = GetAll().Where(p => p.Name.Contains(searchTxt, StringComparison.OrdinalIgnoreCase));

            foreach (var p in results)
                Console.WriteLine($"Found: {p.Name}, Age: {p.Age}");                       

        }

        public void Operations()
        {
            Console.WriteLine("");
            Console.WriteLine("Operations");
            Console.WriteLine("Enter 1 for Add Contact");
            Console.WriteLine("Enter 2 for Search Contact");
            Console.WriteLine("");

            string op = Console.ReadLine();
            if (op == "1")
            {
                AddContact();
            }
            else
            {
                Search();
            }
        }
        public List<ContactPerson> GetAll()
        {
            if (!File.Exists(fileName)) return new List<ContactPerson>();
            string json = File.ReadAllText(fileName);
            return JsonConvert.DeserializeObject<List<ContactPerson>>(json) ?? new List<ContactPerson>();
        }
    }
}



