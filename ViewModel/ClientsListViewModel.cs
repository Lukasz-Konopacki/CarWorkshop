using CarWorkshop.Model;
using CarWorkshop.Services;
using CarWorkshop.Views;
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
        private readonly INavigationService _navigation;
        private readonly IClientService _clientService;

        [ObservableProperty]
        private List<ClientViewModel> _clientsView;

        public ClientsListViewModel(INavigationService navigation, IClientService clientService)
        {
            _navigation = navigation;
            _clientService = clientService;

            RefreshData();
        }


        public void RefreshData()
        {
            var clients = _clientService.GetAllClients().ToList();
            _clientsView = ClientsListToViewModel(clients);
        }

        private List<ClientViewModel> ClientsListToViewModel(List<Client> clients)
        {
            var result = new List<ClientViewModel>();

            foreach (var client in clients)
            {
                result.Add(new ClientViewModel(client));
            }
            return result;
        }

        [RelayCommand]
        public void AddNewClient()
        {
            _navigation.NavigateTo<AddClientViewModel>();
        }

        [RelayCommand]
        public void DeleteClient(string Id)
        {
            _clientService.DeleteClient(new Guid(Id));
            RefreshData();
        }

        [RelayCommand]
        public void DetailsClient(string Id)
        {
            _navigation.NavigateTo<ClientDetailsViewModel>(new Guid(Id));
        }
    }

    public class ClientViewModel : ViewModelBase
    {
        private Client _client { get; set; }
        public string Id => _client.Id.ToString();
        public string Pesel => _client.Pesel;
        public string FullName => _client.FirstName + " " + _client.LastName;
        public string Adress => _client.Address is not null ? _client.Address.Street + " " + _client.Address.BuildingNumber + (_client.Address.FlatNumber is not null ? "/" + _client.Address.FlatNumber : "") : "";
        public string City => _client.Address is not null ? _client.Address.City : "";

        public ClientViewModel(Client client)
        {
            _client = client;
        }
    }
}
