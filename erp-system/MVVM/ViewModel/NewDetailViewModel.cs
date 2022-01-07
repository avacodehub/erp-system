using Microsoft.Toolkit.Mvvm.ComponentModel;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erp_system.MVVM.ViewModel
{
    public class NewDetailViewModel : ObservableObject
    {
        private long _count;

        public long Count
        {
            get => _count;
            set => SetProperty(ref _count, value);
        }

        public NewDetailViewModel()
        {
            Count = Repo.ErpRepo.Details.CountDocuments("{}");
        }
    }
}
