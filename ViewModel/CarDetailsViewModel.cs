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
    public partial class CarDetailsViewModel :ViewModelBase
    {
        private readonly ICarService _carService;
        private readonly IRepairService _repairService;
        private readonly INavigationService _navigationService;

        [ObservableProperty]
        private Car _car;

        [ObservableProperty]
        private ObservableCollection<Repair> _repairs;

        public string Name => _car.Brand + " " + _car.Model;
        public string VIN => _car.VIN;
        public string PlateNumer => _car.PlateNumer;
        public string Brand => _car.Brand;
        public int YearOfProduce => _car.YearOfProduce;


        public CarDetailsViewModel(Guid carId, ICarService carService, IRepairService repairService, INavigationService navigationService)
        {
            _carService = carService;
            _repairService = repairService;
            _navigationService = navigationService;
            _car = _carService.GetCarById(carId);
            _repairs = new ObservableCollection<Repair>(_car.Repairs);
        }

        [RelayCommand]
        public void AddNewRepair()
        {
            _navigationService.NavigateTo<AddRepairViewModel>(_car);
        }

        [RelayCommand]
        public void DetailsRepair(Repair repair) 
        {
            _navigationService.NavigateTo<RepairDetailViewModel>(repair.Id);
        }

        [RelayCommand]
        public void DeleteRepair(Repair repair)
        {
            _repairService.DeleteRepair(repair);
            _repairs.Remove(repair);
        }
    }
}
