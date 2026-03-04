using ContactManager.Utility;
using ContactNS;
using Services;

ContactManagerConsole ct = new ContactManagerConsole();
while (true)
{
    ct.Operations();
}

namespace ContactNS
{
    
    public class ContactManagerConsole
    {
        static string fileName = "contactPerson.json";
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

                IPersistanceService persistanceService = new DBPersistanceService(fileName);
                ContactService contactService = new ContactService(persistanceService);

                try
                {
                    contactService.SaveContact(contactPersons);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Validation "+ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception " + ex.Message);
                }
            }
        }
        public void Search()
        {
            Console.WriteLine("Enter name to search..");

            string searchTxt = Console.ReadLine() ?? string.Empty;

            IPersistanceService persistanceService = new DBPersistanceService(fileName);
            ContactService contactService = new ContactService(persistanceService);

            var results = contactService.SearchByName(searchTxt);

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

            IPersistanceService persistanceService = new DBPersistanceService(fileName);
            ContactService contactService = new ContactService(persistanceService);

            return contactService.GetAllContacts();
        }
    }
}



