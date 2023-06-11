using CarWorkshop.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;

namespace CarWorkshop.ViewModel
{
    public partial class LogInViewModel : ViewModelBase
    {
        private readonly IAccessServie _accessServie;
        private readonly INavigationService _navigation;

        [ObservableProperty]
        private string? _username;
        [ObservableProperty]
        private string? _password;

        public LogInViewModel(IAccessServie accessServie, INavigationService navigation)
        {
            _accessServie = accessServie;
            _navigation = navigation;
        }

        [RelayCommand]
        public void CheckLogIn()
        {
            _navigation.NavigateTo<HomeViewModel>();
        }
    }
}
