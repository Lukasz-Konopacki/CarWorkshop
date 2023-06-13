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

        private List<CarViewModel> _cars;

        public CarListViewModel(INavigationService navigation, ICarService carService)
        {
            _navigation = navigation;
            _carService = carService;

            RefreshData();
        }

        public void RefreshData()
        {
            var cars = _carService.GetAllCars().ToList();
            _cars = carsListToViewModel(cars);
        }

        private List<CarViewModel> carsListToViewModel(List<Car> cars)
        {
            var result = new List<CarViewModel>();

            foreach (var car in cars)
            {
                result.Add(new CarViewModel(car));
            }
            return result;
        }

        [RelayCommand]
        public void AddNewCar()
        {
            _navigation.NavigateTo<AddClientViewModel>();
        }

        [RelayCommand]
        public void DeleteCar(string Id)
        {
            _carService.DeleteCar(new Guid(Id));
            RefreshData();
        }
    }
}
