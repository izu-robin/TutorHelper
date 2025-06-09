using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorHelper.Model;

namespace TutorHelper.ViewModel
{
    class GroupsVM : Utilities.ViewModelBase
    {
        private readonly PageModel _pageModel;
        public DateOnly DisplayOrderDate
        {
            get { return _pageModel.OrderDate; }
            set { _pageModel.OrderDate = value; OnPropertyChanged(); }
        }

        public GroupsVM()
        {
            _pageModel = new PageModel();
            DisplayOrderDate = DateOnly.FromDateTime(DateTime.Now);
        }
    }
}
