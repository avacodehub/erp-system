using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Windows.Input;

namespace erp_system.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {

        public RelayCommand NewDetailCommand { get; set; }
        public RelayCommand FilterCommand { get; set; }

        public NewDetailViewModel NewDetailVM { get; set; }
        public FilterViewModel FilterVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get => _currentView;
            set => SetProperty(ref _currentView, value);
        }

        public MainViewModel()
        {
            NewDetailVM = new NewDetailViewModel();

            FilterVM = new FilterViewModel();

            CurrentView = NewDetailVM;

            NewDetailCommand = new RelayCommand(() =>
            {
                CurrentView = NewDetailVM;
            });

            FilterCommand = new RelayCommand(() =>
            {
                CurrentView = FilterVM;
            });
        }
    }
}
