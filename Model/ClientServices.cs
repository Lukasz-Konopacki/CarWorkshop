using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Model
{
    public class ClientServices
    {
        private List<Client> _clients { get; set;}

        public ClientServices() 
        {
            _clients = new List<Client>()
            {
                new Client("Jan", "Kowalski", "91062302272", "+48666444000", "111-111", new Address("Wroclaw","Skarbowcow", "53-033" , "Polska", "1a")),
                new Client("Wojtek", "Borowski", "2789120111", "+48666444000", "111-111", new Address("Wroclaw","Skarbowcow", "53-033" , "Polska", "1a")),
                new Client("Maciek", "Małysz", "12463302272", "+48666444000", "111-111", new Address("Wroclaw","Skarbowcow", "53-033" , "Polska", "1a")),
            };
        }

        public List<Client> GetAll()
        {
            return _clients;
        }
    }
}
