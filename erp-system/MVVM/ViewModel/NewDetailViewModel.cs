using erp_system.MVVM.Model;
using erp_system.Stores;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using MongoDB.Driver;
using System;

namespace erp_system.MVVM.ViewModel
{
    public class NewDetailViewModel : ObservableObject
    {
        private object _currentView;

        public object CurrentView
        {
            get => _currentView;
            set => SetProperty(ref _currentView, value);
        }

        private Detail Detail { get; set; }

        private DetailBasic _detailBasic;

        public DetailBasic DetailBasic
        {
            get => _detailBasic;
            set => SetProperty(ref _detailBasic, value);
        }

        private DetailFull _detailFull;

        public DetailFull DetailFull
        {
            get => _detailFull;
            set => SetProperty(ref _detailFull, value);
        }


        public NewDetailViewModel()
        {
            Detail = new Detail();
            DetailBasic = new DetailBasic();
            DetailFull = new DetailFull();
            CurrentView = new NewDetailIdViewModel(DetailBasic, OnForward);

        }

        public void OnForward(DetailBasic detailBasic)
        {
            if (detailBasic == null) return;

            Detail.Number = Int32.Parse(detailBasic.Number);
            Detail.Description = detailBasic.Description;
            Detail.DrawingNum = detailBasic.DrawingNumber;

            DetailsStore.Details.InsertOne(Detail);

            DetailFull = new DetailFull
            {
                Number = detailBasic.Number,
                Description = detailBasic.Description,
                DrawingNumber = detailBasic.DrawingNumber,
            };
            CurrentView = new NewDetailRestViewModel(DetailFull, OnBack, OnSave);
        }


        public void OnBack()
        {
            CurrentView = new NewDetailIdViewModel(DetailBasic, OnForward);
        }

        public void OnSave(DetailFull detailFull)
        {
            if (detailFull == null) return;

            Detail.Revision = Int32.Parse(detailFull.Revision);
            Detail.Name = detailFull.Name;
            var filter = Builders<Detail>.Filter.Eq(s => s.Id, Detail.Id);
            DetailsStore.Details.ReplaceOne(filter, Detail);
        }
    }
}
