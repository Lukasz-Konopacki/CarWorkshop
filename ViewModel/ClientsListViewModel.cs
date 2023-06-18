using CarWorkshop.Model;
using CarWorkshop.Services;
using CarWorkshop.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<ClientViewModel> _clientsView;

        public ClientsListViewModel(INavigationService navigation, IClientService clientService)
        {
            _navigation = navigation;
            _clientService = clientService;

            var clients = _clientService.GetAllClients().ToList();
            _clientsView = ClientsListToViewModel(clients);
        }

        private ObservableCollection<ClientViewModel> ClientsListToViewModel(List<Client> clients)
        {
            var result = new ObservableCollection<ClientViewModel>();

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
        public void DeleteClient(ClientViewModel clientViewModel)
        {
            _clientService.DeleteClient(clientViewModel.Client);
            _clientsView.Remove(clientViewModel);
        }

        [RelayCommand]
        public void DetailsClient(ClientViewModel clientViewModel)
        {
            _navigation.NavigateTo<ClientDetailsViewModel>(clientViewModel.Id);
        }
    }

    public class ClientViewModel : ViewModelBase
    {
        public Client Client { get; private set; }
        public Guid Id => Client.Id;
        public string Pesel => Client.Pesel;
        public string FullName => Client.FirstName + " " + Client.LastName;
        public string Adress => Client.Address is not null ? Client.Address.Street + " " + Client.Address.BuildingNumber + (Client.Address.FlatNumber is not null ? "/" + Client.Address.FlatNumber : "") : "";
        public string City => Client.Address is not null ? Client.Address.City : "";

        public ClientViewModel(Client client)
        {
            Client = client;
        }
    }
}
