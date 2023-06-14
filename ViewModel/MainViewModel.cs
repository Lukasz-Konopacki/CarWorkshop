using CarWorkshop.Services;
using CarWorkshop.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.ViewModel
{
    public partial class MainViewModel : ViewModelBase
    {
        [ObservableProperty]
        private INavigationService _navigation;

        public MainViewModel(INavigationService navigationService)
        {
            _navigation = navigationService;
            _navigation.NavigateTo<ClientsListViewModel>();
        }

        [RelayCommand]
        public void NavigateHome()
        {
            _navigation.NavigateTo<HomeViewModel>();
        }

        [RelayCommand]
        public void NavigateToClientList()
        {
            _navigation.NavigateTo<ClientsListViewModel>();
        }

        [RelayCommand]
        public void NavigateToCarList()
        {
            _navigation.NavigateTo<CarListViewModel>();
        }
    }
}
