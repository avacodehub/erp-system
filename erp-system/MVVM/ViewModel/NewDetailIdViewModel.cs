using erp_system.MVVM.Model;
using erp_system.Stores;
using erp_system.Tools;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace erp_system.MVVM.ViewModel
{
    public class NewDetailIdViewModel : ObservableObject
    {
        public ICommand ForwardCommand { get; set; }

        private DetailBasic _detailBasic;

        public DetailBasic DetailBasic
        {
            get => _detailBasic;
            set => SetProperty(ref _detailBasic, value);
        }

        private bool _autoId = true;

        public bool AutoId
        {
            get => _autoId;
            set => SetProperty(ref _autoId, value);
        }

        public NewDetailIdViewModel(DetailBasic detailBasic, Action<DetailBasic?> onForward)
        {
            _detailBasic = detailBasic;
            List<int> existing = DetailsStore.Details.Find(x => x.Number >= 0).ToList().Select(z => z.Number).ToList();

            DetailBasic.Number = IdGenerator.CreateId(existing).ToString();

            ForwardCommand = new RelayCommand<DetailBasic>(onForward, ForwardCommandCanExecute);
        }

        private bool ForwardCommandCanExecute(DetailBasic? detailBasic)
        {
            if (detailBasic == null) return false;
            if (String.IsNullOrEmpty(detailBasic.DrawingNumber)) return false;

            return true;
        }

    }
}
