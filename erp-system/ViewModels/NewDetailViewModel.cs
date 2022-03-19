using erp_system.Model;
using erp_system.Repo;
using erp_system.Stores;
using erp_system.Tools;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace erp_system.ViewModels
{
    public class NewDetailViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;


        public ICommand ConfirmIdCommand { get; set; }

        public NewDetailIdViewModel NewDetailIdVM { get; set; }
        public NewDetailRestViewModel NewDetailRestVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get => _currentView;
            set => SetProperty(ref _currentView, value);
        }

        public NewDetailViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;

            NewDetailRestVM = new NewDetailRestViewModel();

            ConfirmIdCommand = new RelayCommand<ObservableBasicDetail>((ObservableBasicDetail detail) =>
            {
                int _number;
                bool isParsed = Int32.TryParse(detail.Number, out _number);
                if (isParsed)
                {
                    Detail = new Detail
                    { 
                        Number = _number, 
                        DrawingNum = detail.DrawingNumber, 
                        Description = detail.Description 
                    };

                    ErpRepo.Details.InsertOne(Detail);

                    CurrentView = new NewDetailRestViewModel(Detail);
                }
            });

            NewDetailIdVM = new NewDetailIdViewModel(ConfirmIdCommand);

            CurrentView = NewDetailIdVM;

        }
    }
}
