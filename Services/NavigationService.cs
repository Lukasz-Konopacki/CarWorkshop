using CarWorkshop.ViewModel;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Services
{
    public interface INavigationService
    {
        void NavigateTo<TViewModel>() 
            where TViewModel : ViewModelBase;

        INavigationService WithParam(string name, object value);
    }

    public class NavigationService : ObservableObject, INavigationService
    {
        private Dictionary<string, object> Params { get; set; }

        private ViewModelBase? _currentView;
        private Func<Type ,ViewModelBase> _viewModelFactory;

        public ViewModelBase CurrentView 
        { 
            get => _currentView; 
            private set
            {
                _currentView = value;
                OnPropertyChanged();
            }

        }

        public NavigationService(Func<Type ,ViewModelBase> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
            Params = new Dictionary<string, object>();
        }

        public void NavigateTo<TViewModel>() where TViewModel : ViewModelBase
        {
            //Stworzenie nowego viewModelu na podstawie przekazanego typu
            var viewModel = _viewModelFactory(typeof(TViewModel));

            //Ustawienie parametrów przekazanych do serwisu nawigacji w celu przekazania ich dalej
            foreach(var param in Params)
            {
                viewModel.GetType().GetProperty(param.Key)?.SetValue(viewModel, param.Value);
            }

            CurrentView = viewModel;

            //po udanym przejsciu do nowego viewmodulu czyścimy parametry wejsciowe
            Params.Clear();
        }

        public INavigationService WithParam(string name, object value)
        {
            Params.Add(name, value);

            return this;
        }
    }
}
