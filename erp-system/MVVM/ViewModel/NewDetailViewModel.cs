using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace erp_system.MVVM.ViewModel
{
    public class NewDetailViewModel : ObservableObject
    {
        private long _count;

        public long Count
        {
            get => _count;
            set => SetProperty(ref _count, value);
        }

        public NewDetailViewModel()
        {
            Count = Repo.ErpRepo.Details.CountDocuments("{}");
        }
    }
}
