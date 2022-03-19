using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erp_system.MVVM.Model
{
    public class DetailFull : DetailBasic
    {
        private string _name;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _revision;

        public string Revision
        {
            get => _revision;
            set => SetProperty(ref _revision, value);
        }
    }
}
