using erp_system.Repo;
using erp_system.Tools;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erp_system.MVVM.ViewModel
{
    public class NewDetailIdViewModel : ObservableObject
    {
        public RelayCommand ConfirmIdCommand { get; set; }

        private int _number;
        public int Number
        {
            get => _number;
            set => SetProperty(ref _number, value);
        }

        private long _drawingNumber;

        public long DrawingNumber
        {
            get => _drawingNumber;
            set => SetProperty(ref _drawingNumber, value);
        }

        private long _description;

        public long Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        public NewDetailIdViewModel(RelayCommand confirmIdCommand)
        {
            //Count = Repo.ErpRepo.Details.CountDocuments("{}");
            List<int> existing = ErpRepo.Details.Find(x => x.Number >= 0).ToList().Select(z => z.Number).ToList();

            var _generator = new IdGenerator();
            Number = _generator.CreateId(existing);

            ConfirmIdCommand = confirmIdCommand;

        }

    }
}
