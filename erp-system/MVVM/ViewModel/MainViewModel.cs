using Microsoft.Toolkit.Mvvm.ComponentModel;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace erp_system.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        //public MongoClient MongoClient { get; set; }

        public NewDetailViewModel NewDetailVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get => _currentView;
            set => SetProperty(ref _currentView, value);
        }


        public MainViewModel()
        {
            //var settings = MongoClientSettings.FromConnectionString("mongodb+srv://rw-user:RW-user12@cluster0.0rdkc.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
            //MongoClient = new MongoClient(settings);

            NewDetailVM = new NewDetailViewModel();

            CurrentView = NewDetailVM;
        }

    }
}
