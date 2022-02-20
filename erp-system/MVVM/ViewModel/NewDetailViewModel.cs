using erp_system.Repo;
using erp_system.Tools;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace erp_system.MVVM.ViewModel
{
    public class NewDetailViewModel : ObservableObject
    {
        public RelayCommand ConfirmIdCommand { get; set; }

        public NewDetailIdViewModel NewDetailIdVM { get; set; }
        public NewDetailRestViewModel NewDetailRestVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get => _currentView;
            set => SetProperty(ref _currentView, value);
        }

        public NewDetailViewModel()
        {
            NewDetailRestVM = new NewDetailRestViewModel();

            ConfirmIdCommand = new RelayCommand(() =>
            {
                CurrentView = NewDetailRestVM;
            });

            NewDetailIdVM = new NewDetailIdViewModel(ConfirmIdCommand);

            CurrentView = NewDetailIdVM;
            
        }
    }
}
