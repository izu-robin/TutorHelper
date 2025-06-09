using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorHelper.Model;

namespace TutorHelper.ViewModel
{
    class PricingVM : Utilities.ViewModelBase
    {

        private readonly PageModel _pageModel;
        public decimal TransactionAmount
        {
            get { return _pageModel.TransactionValue; }
            set { _pageModel.TransactionValue = value; OnPropertyChanged(); }
        }

        public PricingVM()
        {
            _pageModel = new PageModel();
            TransactionAmount = 100;
        }

    }
}
