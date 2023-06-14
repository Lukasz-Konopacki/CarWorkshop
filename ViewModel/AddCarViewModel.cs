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
        public string _plateNumer;
        [ObservableProperty]
        public string _brand;
        [ObservableProperty]
        public int? _yearOfProduce;

        private Guid _clientId;
        private readonly ICarService _carService;
        private readonly INavigationService _navigationService;

        public AddCarViewModel(Guid clientId,ICarService carService, INavigationService navigationService)
        {
            _clientId = clientId;
            _carService = carService;
            _navigationService = navigationService;
        }

        [RelayCommand]
        public void AddCar()
        {
            _carService.AddCar(_plateNumer, _vIN, _brand, _yearOfProduce, _clientId);
            _navigationService.NavigateTo<ClientDetailsViewModel>(_clientId);
        }
    }
}
