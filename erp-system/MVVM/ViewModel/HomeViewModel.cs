using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erp_system.MVVM.ViewModel
{
    public  class HomeViewModel
    {
        public string  Tooltip { get; set; }
        public string DeveloperInfo { get; set; } = "Created by avacodehub & pi.engineering";
        public string CurrentYear { get; set; }

        public HomeViewModel()
        {
            Tooltip = "Start by creating new detail";
            CurrentYear = DateTime.Today.Year.ToString();
        }
    }

}
