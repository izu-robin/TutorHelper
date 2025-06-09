using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorHelper.Model;

namespace TutorHelper.ViewModel
{
    class LessonsVM : Utilities.ViewModelBase
    {

        private readonly PageModel _pageModel;
        public string ProductAvailability
        {
            get { return _pageModel.ProductStatus; }
            set { _pageModel.ProductStatus = value; OnPropertyChanged(); }
        }

        public LessonsVM()
        {
            _pageModel = new PageModel();
            ProductAvailability = "Нет запланированных занятий";
        }

    }
}
