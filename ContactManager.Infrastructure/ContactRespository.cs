using ContactManager.Utility;
using Microsoft.Data.Sqlite;
using Newtonsoft.Json;
using System.Configuration;
using System.Data;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace ContactManager.Infrastructure
{
    public class ContactRespository
    {
        string _connection;
        public ContactRespository()
        {
            _connection = ConfigurationManager.ConnectionStrings["ContactManagerDb"].ConnectionString;
        }
        public string Get()
        {
            string jsonResult = string.Empty;

            using (var connection = new SqliteConnection(_connection))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM Contact";

                using (var command = new SqliteCommand(selectQuery, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        var dataTable = new DataTable();
                        dataTable.Load(reader);

                        jsonResult = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
                    }
                }
            }
            return jsonResult;
        }
        public void Save(string json)
        {
            List<ContactPerson> contactPerson = JsonConvert.DeserializeObject<List<ContactPerson>>(json);

            using (SqliteConnection connectionSq = new SqliteConnection(_connection))
            {
                connectionSq.Open();
                foreach (var person in contactPerson)
                {
                    string checkIfExistsQuery = "SELECT COUNT(*) FROM Contact WHERE Name = @Name";
                    using (SqliteCommand checkCommand = new SqliteCommand(checkIfExistsQuery, connectionSq))
                    {
                        checkCommand.Parameters.AddWithValue("@Name", person.Name);
                        int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                        if (count == 0)
                        {
                            string insertQuery = "INSERT INTO Contact (Name, Age,Country,Phone) VALUES (@Name, @Age, @Country,@Phone)";
                            using (SqliteCommand insertCommand = new SqliteCommand(insertQuery, connectionSq))
                            {
                                insertCommand.Parameters.AddWithValue("@Name", person.Name);
                                insertCommand.Parameters.AddWithValue("@Age", person.Age);
                                insertCommand.Parameters.AddWithValue("@Country", person.Country);
                                insertCommand.Parameters.AddWithValue("@Phone", person.Phone);

                                insertCommand.ExecuteNonQuery();
                                Console.WriteLine($"Inserted new record for {person.Name}");
                            }
                        }
                    }
                }
            }
        }
    }
}
