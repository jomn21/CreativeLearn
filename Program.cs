// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Data;
using System.Net.Http.Json;
//using System.Text.Json;
using ContactNS;
using ContactNSPerson;

Contact ct = new Contact();
ct.Operations();
ct.AddContact();


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


                if (!File.Exists(fileName))
                {
                    string fileData = JsonConvert.SerializeObject(contactPerson, Formatting.Indented);

                    File.WriteAllText(fileName, fileData);


                    Console.WriteLine("Saved to file");
                }
                else
                {

                    IList<ContactPerson> contactPersons = new List<ContactPerson>();

                    string jsonContact = File.ReadAllText(fileName);
                                        
                    string fileData = JsonConvert.SerializeObject(contactPerson, Formatting.Indented);


                    File.AppendAllText(fileName, fileData);

                }

                Operations();
            }
        }

        public void Search()
        {
            Console.WriteLine("Enter name to search..");

            string searchTxt = Console.ReadLine() ?? string.Empty;

            IList<ContactPerson> contactPersons = new List<ContactPerson>();

            if (File.Exists(fileName))
            {
                string jsonContact = File.ReadAllText(fileName);


                JsonTextReader reader = new JsonTextReader(new StringReader(jsonContact));
                reader.SupportMultipleContent = true;

                while (true)
                {
                    if (!reader.Read())
                    {
                        break;
                    }

                    JsonSerializer serializer = new JsonSerializer();
                    ContactPerson CP = serializer.Deserialize<ContactPerson>(reader);

                    contactPersons.Add(CP);
                }

                List<ContactPerson> cpAll = contactPersons.Where(p => p.Name == searchTxt).ToList();

                foreach (ContactPerson cp in cpAll)
                {
                    Console.WriteLine("Searched Name " + cp.Name + " Age " + cp.Age);
                }

                if (cpAll.Count == 0)
                {
                    Console.WriteLine("No data found");
                }

                Console.WriteLine("");
                Operations();

            }
            else
            {
                Console.WriteLine("No data found");
                Console.WriteLine("");
                Operations();

            }


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
    }
}



