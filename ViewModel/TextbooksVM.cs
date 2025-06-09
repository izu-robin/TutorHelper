using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorHelper.Model;

namespace TutorHelper.ViewModel
{
    class TextbooksVM : Utilities.ViewModelBase
    {
        private readonly PageModel _pageModel;
        public TimeOnly ShipmentTracking
        {
            get { return _pageModel.ShipmentDelivery; }
            set { _pageModel.ShipmentDelivery = value; OnPropertyChanged(); }
        }

        public TextbooksVM()
        {
            _pageModel = new PageModel();
            TimeOnly time = TimeOnly.FromDateTime(DateTime.Now);
            ShipmentTracking = time;


        }
    }
}
