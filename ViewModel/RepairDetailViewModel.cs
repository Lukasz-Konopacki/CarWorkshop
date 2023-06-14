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
    public partial class RepairDetailViewModel :ViewModelBase
    {
        private readonly Guid _repairId;
        private readonly IRepairService _repairService;
        [ObservableProperty]
        private Repair? _repair;

        public string CarVin => _repair.CarVin;
        public decimal? Price => _repair.Price;
        public int SummaryWorkingHours => _repair.SummaryWorkingHours;
        public DateTime StartDate => _repair.StartDate;
        public DateTime EndDate => _repair.EndDate;

        [ObservableProperty]
        public ObservableCollection<Part> _parts;

        [ObservableProperty]
        private string? _newPartName;
        [ObservableProperty]
        private decimal _newPartPrice;
        [ObservableProperty]
        private int _newPartQuantity;


        public RepairDetailViewModel(Guid repairId, IRepairService repairService)
        {
            _repairId = repairId;
            _repairService = repairService;
            RefreshData();
        }

        public void RefreshData()
        {
            _repair = _repairService.GetRepairById(_repairId);
            _parts = new ObservableCollection<Part>(_repair.parts);
        }

        [RelayCommand]
        public void AddPart()
        {
            _repairService.AddPart(Guid.NewGuid(), _newPartName, _newPartPrice, _newPartQuantity, _repairId);
            RefreshData();
        }
    }
}
