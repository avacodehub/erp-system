using erp_system.Model;
using erp_system.Repo;
using erp_system.Tools;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace erp_system.ViewModels
{
    public class NewDetailIdViewModel : ViewModelBase
    {
        public ICommand ConfirmIdCommand { get; set; }

        private ObservableBasicDetail _oDetail;

        public ObservableBasicDetail ODetail
        {
            get => _oDetail;
            set => SetProperty(ref _oDetail, value);
        }

        public NewDetailIdViewModel()
        {
            //Count = Repo.ErpRepo.Details.CountDocuments("{}");
            List<int> existing = ErpRepo.Details.Find(x => x.Number >= 0).ToList().Select(z => z.Number).ToList();

            var _generator = new IdGenerator();
            ODetail = new ObservableBasicDetail();
            ODetail.Number = _generator.CreateId(existing).ToString();
        
            ConfirmIdCommand = new RelayCommand<ObservableBasicDetail>((ObservableBasicDetail detail) => AddBasicDetail(detail);
        }

        public void AddBasicDetail(ObservableBasicDetail detail)
        {
                int _number;
                bool isParsed = Int32.TryParse(detail.Number, out _number);
                if (isParsed)
                {
                    Detail = new Detail
                    {
                        Number = _number,
                        DrawingNum = detail.DrawingNumber,
                        Description = detail.Description
                    };

                    ErpRepo.Details.InsertOne(Detail);

                    CurrentView = new NewDetailRestViewModel(Detail);
                }
        }

    }

    public class ObservableBasicDetail : ObservableObject
    {
        private int _number;
        public string Number
        {
            get => String.Format("{0:00000000}",
                              _number);
            set => SetProperty(ref _number, Int32.Parse(value));
        }

        private string _drawingNumber;

        public string DrawingNumber
        {
            get => _drawingNumber;
            set => SetProperty(ref _drawingNumber, value);
        }

        private string _description;

        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }
    }
}
