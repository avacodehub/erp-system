using erp_system.Data;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erp_system.ViewModels
{
    public class DetailViewModel : ObservableObject
    {
        private readonly Detail _detail;

        public int Number => _detail.Number;

        public string Name => _detail.Name;

        public string Description => _detail.Description;

        public DetailViewModel(Detail detail)
        {
            _detail = detail;
        }

    }
}
