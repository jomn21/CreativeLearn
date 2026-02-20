using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{

    public class ContactService
    {
        PersistanceService _persistanceService; 
        public ContactService(PersistanceService persistanceService)
        {
            _persistanceService= persistanceService;
        }
        public void SaveContact(string fileName, string json)
        {
            _persistanceService.SaveService(fileName, json);
        }

    }
}
