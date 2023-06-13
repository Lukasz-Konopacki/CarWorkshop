using CarWorkshop.Model;
using CarWorkshop.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.ViewModel
{
    public partial class AddClientViewModel : ViewModelBase
    {
        private readonly IClientService _clientService;
        private readonly INavigationService _navigationService;

        [ObservableProperty]
        private string _firstName;
        [ObservableProperty]
        public string _lastName;
        [ObservableProperty]
        public string _pesel;

        [ObservableProperty]
        private string _contactNumber;
        [ObservableProperty]
        private string? _nipNumber;

        [ObservableProperty]
        public string? _city;
        [ObservableProperty]
        public string? _street;
        [ObservableProperty]
        public string? _postalCode;
        [ObservableProperty]
        public string? _country;
        [ObservableProperty]
        public string? _buildingNumber;
        [ObservableProperty]
        public string? _flatNumber;


        public AddClientViewModel(IClientService clientService, INavigationService navigationService)
        {
            _clientService = clientService;
            _navigationService = navigationService;
        }

        [RelayCommand]
        public void AddClient()
        {
            _clientService.AddClient(_firstName,_lastName,_pesel,_contactNumber,_nipNumber, _city, _street, _postalCode, _country, _buildingNumber, _flatNumber);
            _navigationService.NavigateTo<ClientsListViewModel>();
        }
    }
}
