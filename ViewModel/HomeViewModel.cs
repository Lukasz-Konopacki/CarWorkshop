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
    public partial class HomeViewModel : ViewModelBase
    {
        private INavigationService _navigation;

        public HomeViewModel(INavigationService navigationService)
        {
            _navigation = navigationService;
            _navigation.NavigateTo<LogInViewModel>();
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
    }
}
