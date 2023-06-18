using CarWorkshop.Model;
using CarWorkshop.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static CarWorkshop.Services.RepairService;

namespace CarWorkshop.ViewModel
{
    public partial class AddRepairViewModel :ViewModelBase
    {
        private readonly IRepairService _repairService;
        private readonly INavigationService _navigationService;

        private readonly Car _car;
        [ObservableProperty]
        private int _kilometeraga;
        [ObservableProperty]
        private bool _includeOilService;
        [ObservableProperty]
        private string? _problemDescriptionByClient;
        [ObservableProperty]
        private int? _summaryWorkingHours;
        [ObservableProperty]
        private DateTime _startDate;
        [ObservableProperty]
        private DateTime _endDate;
        
        public AddRepairViewModel(Car car, IRepairService repairService, INavigationService navigationService)
        {
            _car = car;
            _repairService = repairService;
            _navigationService = navigationService;
            _startDate = DateTime.Now;
            _endDate = DateTime.Now;
        }

        [RelayCommand]
        public void AddRepair()
        {
            if(checkDate() && checkService())
            {
                _repairService.AddRepair(_car, _kilometeraga, _includeOilService, _problemDescriptionByClient, _startDate.Date, _endDate.Date, _summaryWorkingHours);
                _navigationService.NavigateTo<CarDetailsViewModel>(_car.Id);
            }            
        }

        public bool checkDate()
        {
            var collisionnRepairs = _repairService.GetAllRepairs().Where(r => _startDate.Date <= r.EndDate.Date && _endDate.Date >= r.StartDate.Date).ToList();
            if (collisionnRepairs.Count == 0)
            {
                return true;
            }
            else
            {
                MessageBoxResult result = MessageBox.Show($"In selected date are already register {collisionnRepairs.Count} others repairs. Are you sure you would like to add another one?", "Warning!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    return true;
                }
            }
            return false;
        }

        public bool checkService()
        {
            var NearestService = _repairService.GetAllRepairs().Where(r => r.Car.Id == _car.Id).OrderByDescending(r => _startDate - r.EndDate).FirstOrDefault();
            if (_kilometeraga - NearestService.Kilometerage < 10000)
            {
                return true;
            }
            else
            {
                MessageBoxResult result = MessageBox.Show($"Last oil service was done: {_kilometeraga - NearestService.Kilometerage}km ago. Are you sure the client doesn't want it?", "Warning!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
