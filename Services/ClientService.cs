using CarWorkshop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Services
{
    public interface IClientService
    {
        public List<Client> GetAllClients();
        public Client GetClientById(int id);
    }

    public class ClientService : IClientService
    {
        public List<Client> GetAllClients()
        {
            throw new NotImplementedException();
        }

        public Client GetClientById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
