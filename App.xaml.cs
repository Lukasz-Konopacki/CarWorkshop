using CarWorkshop.DbContexts;
using CarWorkshop.Services;
using CarWorkshop.ViewModel;
using CarWorkshop.Views;
using Microsoft.EntityFrameworkCore;
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
            services.AddSingleton(provaider => new LogInWindow { DataContext = provaider.GetRequiredService<LogInViewModel>() });
            services.AddSingleton<Func<Type, object? ,ViewModelBase>>(provaider => (viewModelType, param) =>
            {
                return param == null ? (ViewModelBase)provaider.GetRequiredService(viewModelType) :  (ViewModelBase)ActivatorUtilities.CreateInstance(provaider, viewModelType, param);
            });

            services.AddTransient<LogInViewModel>();
            services.AddTransient<HomeViewModel>();
            services.AddTransient<ClientsListViewModel>();
            services.AddTransient<ClientDetailsViewModel>();
            services.AddTransient<CarListViewModel>();
            services.AddTransient<AddClientViewModel>();
            services.AddTransient<AddRepairViewModel>();
            services.AddTransient<RepairDetailViewModel>();
            services.AddSingleton<DatabaseContext>();


            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<IAccessServie, AccessServie>();
            services.AddSingleton<IClientService, ClientService>();
            services.AddSingleton<ICarService, CarService>();
            services.AddSingleton<IRepairService, RepairService>();

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainwindow = _serviceProvider.GetRequiredService<LogInWindow>();
            mainwindow.Show();
            base.OnStartup(e);
        }
    }
}
