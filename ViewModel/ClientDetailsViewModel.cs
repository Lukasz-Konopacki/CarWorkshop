using CarWorkshop.Model;
using CarWorkshop.Services;
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
    public partial class ClientDetailsViewModel :ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly ICarService _carService;
        [ObservableProperty]
        private Client _client;
        public string Pesel => _client.Pesel;
        public string FullName => _client.FirstName + " " + _client.LastName;
        public string Adress => _client.Address is not null ? _client.Address.Street + " " + _client.Address.BuildingNumber + (_client.Address.FlatNumber is not null ? "/" + _client.Address.FlatNumber : "") : "";
        public string PostalCode => _client.Address is not null ? _client.Address.PostalCode : "";
        public string City => _client.Address is not null ? _client.Address.City : "";
        public string ContactNumber => _client.ContactNumber ?? "";
        public string NipNumber => _client.NipNumber ?? "";

        [ObservableProperty]
        public ObservableCollection<Car> _cars;


        public ClientDetailsViewModel(Guid clientId, IClientService clientService, ICarService carService ,INavigationService navigationService)
        {
            _carService = carService;
            _navigationService = navigationService;

            _client = clientService.GetClientById(clientId);
            _cars = new ObservableCollection<Car>(_client.Cars);
        }

        [RelayCommand]
        public void AddNewCar()
        {
            _navigationService.NavigateTo<AddCarViewModel>(_client);
        }

        [RelayCommand]
        public void DeleteCar(Car car)
        {
            _carService.DeleteCar(car);
            _cars.Remove(car);
        }

        [RelayCommand]
        public void CarDetails(Car car) 
        {
            _navigationService.NavigateTo<CarDetailsViewModel>(car.Id);
        }
    }
}
