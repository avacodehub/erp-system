using erp_system.MVVM.Model;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace erp_system.MVVM.ViewModel
{
    public class NewDetailRestViewModel : ObservableObject
    {
        public ICommand CreateCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        private DetailFull _detailFull;

        public DetailFull DetailFull
        {
            get => _detailFull;
            set => SetProperty(ref _detailFull, value);
        }

        public NewDetailRestViewModel(DetailFull detailFull, Action onBack, Action<DetailFull> onSave)
        {
            DetailFull = detailFull;
            CancelCommand = new RelayCommand(onBack);
            CreateCommand = new RelayCommand<DetailFull>(onSave);
        }

       
    }
}
