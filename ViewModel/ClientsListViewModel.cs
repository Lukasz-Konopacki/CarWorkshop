using CarWorkshop.Model;
using CarWorkshop.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.ViewModel
{
    public partial class ClientsListViewModel : ViewModelBase
    {
        private List<ClientViewModel> _clients;
        public List<ClientViewModel> Clients
        {
            get { return _clients; }
            set { _clients = value; }
        }

        public ClientsListViewModel(INavigationService service)
        {
            _clients = new List<ClientViewModel>()
            {
                new ClientViewModel(new Client("Jan", "Kowalski", "9606301123", "48664458002", "0011", new Address("Wroclaw", "Krzycka", "53-033", "Poland", "14a"))),
                new ClientViewModel(new Client("Waldemar", "Dudud", "9606301123", "48664458002", "0011", new Address("Wroclaw", "Krzycka", "53-033", "Poland", "14a")))
            };
        }

        [RelayCommand]
        public void AddNewClient()
        {

        }
    }
}
