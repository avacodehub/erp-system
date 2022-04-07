using erp_system.Commands;
using erp_system.MVVM.Model;
using erp_system.Stores;
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
    public class FilterViewModel : ObservableObject
    {
        public ICommand SearchCommand { get; set; }

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

        private List<Detail> _results;

        public List<Detail> Results
        {
            get => _results;
            set => SetProperty(ref _results, value);
        }

        public FilterViewModel()
        {
            SearchCommand = new SearchCommand(this);
        }
    }
}
