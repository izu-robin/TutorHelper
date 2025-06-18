using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TutorHelper.DataAccess;
using TutorHelper.Model;
using TutorHelper.Model.Core;
using TutorHelper.Utilities;

namespace TutorHelper.ViewModel
{
    class LessonsVM : Utilities.ViewModelBase
    {
        //конструктор стартовой раскладки 
        public LessonsVM()
        {
            //_pageModel = new PageModel();
            TableStatus = "Предстоящие занятия:";
            LoadFutureLessons();

            //все что на старте надо сделать - всё сюда

        }
        /*
        //private readonly PageModel _pageModel;
        //public string ProductAvailability
        //{
        //    get { return _pageModel.ProductStatus; }
        //    set { _pageModel.ProductStatus = value; OnPropertyChanged(); }
        //} */

        // выбранный урок - но там еще должны быть данные, не только те что идут в верхнюю таблицу. Надо добавить везде еще список с именами учеников

        //статус текущего отображения таблицы
        private string _tableStatus;
        public string TableStatus 
        { get => _tableStatus;
          set
            {
                _tableStatus = value;
                OnPropertyChanged();
            }
        }

        // isChecked для таблицы и вообще всё для toggleButton
        private bool _isDataToggled = true;
        public bool IsDataToggled
        {
            get => _isDataToggled;
            set
            {
                _isDataToggled = value;
                OnPropertyChanged();
                //метод для загрузки:
                LoadDataToggleBtn();
            }
        }
        public ICommand LoadDataToggleCommand => new RelayCommand(() => //(parameter)
        {
            IsDataToggled = !IsDataToggled;
        });

        private void LoadDataToggleBtn()
        {
            if(IsDataToggled)
            {
                FutureLessonsList.Clear();
                //вот тут загружаются занятия по дефолту
                LoadFutureLessons();
                TableStatus = "Предстоящие занятия: ";
            }
            else
            {
                FutureLessonsList.Clear();
                                                    //вот тут функцию, которая забирает в дб занятия Date>=сегодняшняя
                //

                TableStatus =  "Прошедшие занятия: ";
            }
        }

         //текущий список будущих/прошлых уроков
        public ObservableCollection<Lesson> FutureLessonsList { get; } = new();

        //загрузка будущих уроков
        private void LoadFutureLessons()
        {
            foreach (var les in DataBase.GetFutureLessons())
            {
                FutureLessonsList.Add(les);
            }
        }





    }
}
