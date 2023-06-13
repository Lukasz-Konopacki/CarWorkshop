using CarWorkshop.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.ViewModel
{
    public class ClientViewModel : ViewModelBase
    {
        private Client _client {get; set;}
        public string Id => _client.Id.ToString();
        public string Pesel => _client.Pesel;
        public string FullName => _client.FirstName + " " + _client.LastName;
        public string Adress => _client.Address is not null ? _client.Address.Street + " " + _client.Address.BuildingNumber + (_client.Address.FlatNumber is not null ? "/" + _client.Address.FlatNumber : "")  : "";
        public string City => _client.Address is not null ? _client.Address.City : "";

        public ClientViewModel(Client client)
        {
            _client = client;
        }
    }
}
