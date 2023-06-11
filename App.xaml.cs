using CarWorkshop.Services;
using CarWorkshop.ViewModel;
using CarWorkshop.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<MainViewModel>();
            services.AddSingleton(provaider => new MainWindow { DataContext = provaider.GetRequiredService<MainViewModel>() });
            services.AddSingleton<Func<Type, ViewModelBase>>(provaider => viewModelType => (ViewModelBase)provaider.GetRequiredService(viewModelType));

            services.AddSingleton<HomeViewModel>();
            services.AddSingleton<ClientsListViewModel>();
            services.AddSingleton<LogInViewModel>();

            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<IAccessServie, AccessServie>();
            

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainwindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainwindow.Show();
            base.OnStartup(e);
        }
    }
}
