using CarWorkshop.Services;
using CarWorkshop.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace CarWorkshop.ViewModel
{
    public partial class LogInViewModel : ViewModelBase
    {
        private readonly IAccessServie _accessServie;
        private readonly IServiceProvider _serviceProvider;

        [ObservableProperty]
        private string? _username;
        [ObservableProperty]
        private string? _password;

        public LogInViewModel(IServiceProvider serviceProvider,IAccessServie accessServie)
        {
            _accessServie = accessServie;
            _serviceProvider = serviceProvider;
        }

        [RelayCommand]
        public void CheckLogIn(Window winndow)
        {
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
            winndow.Close();
        }
    }
}
