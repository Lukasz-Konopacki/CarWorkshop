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
    public partial class CarDetailsViewModel :ViewModelBase
    {
        private readonly ICarService _clientService;
        private readonly INavigationService _navigationService;
        private string _vin;
        private readonly ICarService _carService;
        [ObservableProperty]
        private Car _car;

        public string Name => _car.Brand + " " + _car.PlateNumer;
        public string VIN => _car.VIN;
        public string PlateNumer => _car.PlateNumer;
        public string Brand => _car.Brand;
        public int YearOfProduce => _car.YearOfProduce;
        public List<Repair> Repairs => _car.Repairs;


        public CarDetailsViewModel(string vin, ICarService carService, INavigationService navigationService)
        {
            _vin = vin;
            _carService = carService;
            _navigationService = navigationService;

            RefreshData();
        }

        public void RefreshData()
        {
            _car = _carService.GetCarByVin(_vin);
        }

        [RelayCommand]
        public void AddNewRepair()
        {
            _navigationService.NavigateTo<AddRepairViewModel>(_vin);
        }

        [RelayCommand]
        public void DetailsRepair(Guid id) 
        {
            _navigationService.NavigateTo<RepairDetailViewModel>(id);
        }
    }
}
