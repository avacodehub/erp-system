using erp_system.Model;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace erp_system.ViewModels
{
    public class NewDetailRestViewModel : ObservableObject
    {
        public ICommand ConfirmIdCommand { get; set; }

        private ObservableBasicDetail _oDetail;

        public ObservableBasicDetail ODetail
        {
            get => _oDetail;
            set => SetProperty(ref _oDetail, value);
        }
        public NewDetailRestViewModel()
        {

        }

        public NewDetailRestViewModel(Detail detail)
        {

        }
    }
}
