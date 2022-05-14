using erp_system.MVVM.Model;
using erp_system.Stores;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace erp_system.MVVM.ViewModel
{
    public class ViewDetailViewModel : ObservableObject
    {
        public ICommand EditCommand { get; set; }
        public ICommand CreateNewCommand { get; set; }

        private DetailFull _detailFull;

        public DetailFull DetailFull
        {
            get => _detailFull;
            set => SetProperty(ref _detailFull, value);
        }

        public ViewDetailViewModel(DetailFull detailFull, Action onCreateNew, Action<DetailFull?> onEdit)
        {
            DetailFull = detailFull;
            EditCommand = new RelayCommand<DetailFull>(onEdit);
            CreateNewCommand = new RelayCommand(onCreateNew);
        }

       
    }
}
