using erp_system.Stores;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Windows.Input;

namespace erp_system.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;

        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        public RelayCommand NewDetailCommand { get; set; }
        public RelayCommand FilterCommand { get; set; }

        public NewDetailViewModel NewDetailVM { get; set; }
        public FilterViewModel FilterVM { get; set; }

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public MainViewModel()
        {
            //NewDetailVM = new NewDetailViewModel();

            //FilterVM = new FilterViewModel();

            //CurrentView = NewDetailVM;

            //NewDetailCommand = new RelayCommand(() =>
            //{
            //    CurrentView = NewDetailVM;
            //});

            //FilterCommand = new RelayCommand(() =>
            //{
            //    CurrentView = FilterVM;
            //});
        }
    }
}
