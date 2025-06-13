using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorHelper.DataAccess;
using TutorHelper.Model;
using TutorHelper.Model.Core;

namespace TutorHelper.ViewModel
{
    class LessonsVM : Utilities.ViewModelBase
    {
        //private readonly PageModel _pageModel;
        //public string ProductAvailability
        //{
        //    get { return _pageModel.ProductStatus; }
        //    set { _pageModel.ProductStatus = value; OnPropertyChanged(); }
        //}

        public ObservableCollection<Lesson> FutureLessonsList { get; } = new();

        public LessonsVM()
        {
           //_pageModel = new PageModel();
       
            LoadFutureLessons();





        }

        private void LoadFutureLessons()
        {
            foreach (var les in DataBase.GetFutureLessons())
            {
                FutureLessonsList.Add(les);
            }
        }


    }
}
