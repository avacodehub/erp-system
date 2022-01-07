using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace erp_system.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        public NewDetailViewModel NewDetailVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get => _currentView;
            set => SetProperty(ref _currentView, value);
        }

        public MainViewModel()
        {
            NewDetailVM = new NewDetailViewModel();

            CurrentView = NewDetailVM;
        }
    }
}
