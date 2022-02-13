using erp_system.Repo;
using erp_system.Tools;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace erp_system.MVVM.ViewModel
{
    public class NewDetailViewModel : ObservableObject
    {
        //public Command<> ForwardCommand { get; set; } = new Command
        private long _count;

        public long Count
        {
            get => _count;
            set => SetProperty(ref _count, value);
        }

        private int _number;
        public int Number
        {
            get => _number;
            set => SetProperty(ref _number, value);
        }
        
        public NewDetailViewModel()
        {
            Count = Repo.ErpRepo.Details.CountDocuments("{}");
            List<int> existing = ErpRepo.Details.Find(x => x.Number >= 0).ToList().Select(z => z.Number).ToList();

            var _generator = new IdGenerator();
            Number = _generator.CreateId(existing);

        }

        public void OnForward()
        {

        }
    }
}
