using CarWorkshop.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CarWorkshop.Services.RepairService;

namespace CarWorkshop.ViewModel
{
    public partial class AddRepairViewModel :ViewModelBase
    {
        private readonly IRepairService _repairService;
        private readonly INavigationService _navigationService;

        private string _carVin;
        [ObservableProperty]
        private string? _problemDescriptionByClient;
        [ObservableProperty]
        private decimal? _price;
        [ObservableProperty]
        private int _summaryWorkingHours;
        [ObservableProperty]
        private DateTime _startDate;
        [ObservableProperty]
        private DateTime _endDate;
        
        public AddRepairViewModel(string vin, IRepairService repairService, INavigationService navigationService)
        {
            _carVin = vin;
            _repairService = repairService;
            _navigationService = navigationService;
            _startDate = DateTime.Now;
            _endDate = DateTime.Now;
        }

        [RelayCommand]
        public void AddRepair()
        {
            _repairService.AddRepair(_carVin, _problemDescriptionByClient, _price, _summaryWorkingHours, _startDate, _endDate, _carVin);
            _navigationService.NavigateTo<CarDetailsViewModel>(_carVin);
        }
    }
}
