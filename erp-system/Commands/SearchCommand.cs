using erp_system.MVVM.ViewModel;
using erp_system.Stores;
using MongoDB.Driver;
using System.Linq;


namespace erp_system.Commands
{
    public class SearchCommand : BaseCommand
    {
        private readonly FilterViewModel _viewModel;

        public SearchCommand(FilterViewModel viewModel)
        {
            _viewModel = viewModel;

            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_viewModel.Name);
        }

        public override void Execute(object? parameter)
        {
            //var res = DetailsStore.Details.Find(x => x.Name.Contains(_viewModel.Name)).ToList();
            var res = DetailsStore.Details.Find(x => true).ToList();
            _viewModel.Results = res;
        }

        private void ViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(FilterViewModel.Name))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
