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
            ClientsView = ClientsListToViewModel(clients);
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
            _navigation.WithParam("ClientId", Id).NavigateTo<ClientDetailsViewModel>();
        }
    }
}
