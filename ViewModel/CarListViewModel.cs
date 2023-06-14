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
    public partial class CarListViewModel :ViewModelBase
    {
        private readonly INavigationService _navigation;
        private readonly ICarService _carService;

        [ObservableProperty]
        private List<Car> _carsList;

        public CarListViewModel(INavigationService navigation, ICarService carService)
        {
            _navigation = navigation;
            _carService = carService;

            RefreshData();
        }

        public void RefreshData()
        {
            _carsList = _carService.GetAllCars().ToList();
        }

        [RelayCommand]
        public void DetailsCar(string vin)
        {
            _navigation.NavigateTo<CarDetailsViewModel>(vin);
        }

        [RelayCommand]
        public void DeleteCar(string vin)
        {
            _carService.DeleteCar(vin);
            RefreshData();
        }
    }
}
