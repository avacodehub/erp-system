using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erp_system.MVVM.Model
{
    public class DetailBasic : ObservableObject
    {
        private int _number;

        public string Number
        {
            get => String.Format("{0:00000000}",
                              _number);
            set => SetProperty(ref _number, Int32.Parse(value));
        }

        private string _description;

        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        private string _drawingNumber;

        public string DrawingNumber
        {
            get => _drawingNumber;
            set => SetProperty(ref _drawingNumber, value);
        }
    }
}
