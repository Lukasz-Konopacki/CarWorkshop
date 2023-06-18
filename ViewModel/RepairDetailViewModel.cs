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
        private readonly IRepairService _repairService;
        
        [ObservableProperty]
        private Repair _repair;
        [ObservableProperty]
        private ObservableCollection<Part> _parts;
        [ObservableProperty]
        private decimal? _price;

        public string CarName => $"{_repair.Car.Brand} {_repair.Car.Model} ({_repair.Car.PlateNumer})";
        public string CarPlateNumber => _repair.Car.PlateNumer;
        public int SummaryWorkingHours => _repair.WorkingHours;
        public string ProblemDescription => _repair.ProblemDescriptionByClient ?? "";
        public DateTime StartDate => _repair.StartDate;
        public DateTime? EndDate => _repair.EndDate;

        [ObservableProperty]
        private string _newPartName;
        [ObservableProperty]
        private decimal _newPartPrice;
        [ObservableProperty]
        private int _newPartQuantity;

        public RepairDetailViewModel(Guid repairId, IRepairService repairService)
        {
            _repairService = repairService;
            _repair = _repairService.GetRepairById(repairId);
            _parts = new ObservableCollection<Part>(_repair.Parts);

            Price = _repair.Price;
        }

        [RelayCommand]
        public void AddPart()
        {
            Part newPart = _repairService.AddPart(_repair, _newPartName, _newPartPrice, _newPartQuantity);
            _parts.Add(newPart);

            Price = _repair.Price;
            
        }

        [RelayCommand]
        public void RemovePart(Part part)
        {
            _repairService.DeletePart(part);
            _parts.Remove(part);
        }
    }
}
