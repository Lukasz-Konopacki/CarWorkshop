using CarWorkshop.Model;
using CarWorkshop.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.ViewModel
{
    public partial class AddCarViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string _vIN;
        [ObservableProperty]
        private string _plateNumer;
        [ObservableProperty]
        private string _brand;
        [ObservableProperty]
        private string _model;
        [ObservableProperty]
        private int _yearOfProduce;

        private Client _client;
        private readonly ICarService _carService;
        private readonly INavigationService _navigationService;

        public AddCarViewModel(Client client,ICarService carService, INavigationService navigationService)
        {
            _client = client;
            _carService = carService;
            _navigationService = navigationService;
        }

        [RelayCommand]
        public void AddCar()
        {
            _carService.AddCar(_client, _plateNumer, _vIN, _brand, _model, _yearOfProduce);
            _navigationService.NavigateTo<ClientDetailsViewModel>(_client.Id);
        }
    }
}
