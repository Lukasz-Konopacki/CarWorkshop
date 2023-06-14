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
    public partial class ClientDetailsViewModel :ViewModelBase
    {
        private readonly IClientService _clientService;
        private readonly INavigationService _navigationService;
        private Guid _clientId;

        [ObservableProperty]
        private Client _client;

        public string Pesel => _client.Pesel;
        public string FullName => _client.FirstName + " " + _client.LastName;
        public string Adress => _client.Address is not null ? _client.Address.Street + " " + _client.Address.BuildingNumber + (_client.Address.FlatNumber is not null ? "/" + _client.Address.FlatNumber : "") : "";
        public string PostalCode => _client.Address is not null ? _client.Address.PostalCode : "";
        public string City => _client.Address is not null ? _client.Address.City : "";
        public string ContactNumber => _client.ContactNumber ?? "";
        public string NipNumber => _client.NipNumber ?? "";
        public List<Car> Cars => _client.Cars;


        public ClientDetailsViewModel(Guid clientId, IClientService clientService, INavigationService navigationService)
        {
            _clientService = clientService;
            _navigationService = navigationService;
            _clientId = clientId;
            RefreshData();

        }
        public void RefreshData()
        {
            _client = _clientService.GetClientById(_clientId);
        }

        [RelayCommand]
        public void AddNewCar()
        {
            _navigationService.NavigateTo<AddCarViewModel>(_clientId);
        }
    }
}
