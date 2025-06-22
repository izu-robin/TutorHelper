using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
            DateToday = CorrectTodayDate(DateTime.Now) ?? "-";
            LoadFutureLessons();
            SelectedLesson = FutureLessonsList[0];
            GetStudents();
            SelectedStudent = new Student();
            SelectedStudent = StudentsList[0];
            
            //все что на старте надо сделать - всё сюда

        }
        /*
        //private readonly PageModel _pageModel;
        //public string ProductAvailability
        //{
        //    get { return _pageModel.ProductStatus; }
        //    set { _pageModel.ProductStatus = value; OnPropertyChanged(); }
        //} */

        //текущий список будущих/прошлых уроков
        public ObservableCollection<Lesson> FutureLessonsList { get; } = new(); 

        public ObservableCollection<Student> StudentsList { get; } = new();

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
                //вот тут загружаются будущие занятия
                LoadFutureLessons();
                TableStatus = "Предстоящие занятия: ";
            }
            else
            {
                FutureLessonsList.Clear();
                //вот тут функцию, которая забирает в дб занятия Date>=сегодняшняя
                LoadPastLessons();

                TableStatus =  "Прошедшие занятия: ";
            }
        }



        //загрузка будущих уроков
        private void LoadFutureLessons()
        {
            foreach (var les in DataBase.GetFutureLessons(DateToday))
            {
                FutureLessonsList.Add(les);
            }
        }

        private void LoadPastLessons()
        {
            foreach (var les in DataBase.GetPastLessons(DateToday))
            {
                FutureLessonsList.Add(les);
            }
            FutureLessonsList.RemoveAt(0);
        }
        public static string? DateToday { get; set; }

        private string CorrectTodayDate(DateTime d)
        {
            string answ = d.ToString();
            string[] arr = answ.Split(' ');
            answ = arr[0];

            return answ;
        }

        

        private void GetStudents()
        {
            foreach ( var stud in DataBase.GetStudents())
            {
                StudentsList.Add(stud);
            }
        }

        private Student _selectedStudent;
        public Student SelectedStudent
        {
            get => _selectedStudent;
            set
            {
                _selectedStudent = value;
                OnPropertyChanged();
                CurrentEditableLesson.StudentID = value?.Id ?? 0;
            }
        }


        private Lesson _selectedLesson;
        public Lesson SelectedLesson
        {
            get => _selectedLesson;
            set
            {
                _selectedLesson = value;
                OnPropertyChanged();

                if (_selectedLesson != null)
                {
                    CurrentEditableLesson = new Lesson(_selectedLesson);
                }
            }
        }


        private Lesson _currentEditableLesson;
        public Lesson CurrentEditableLesson
        {
            get => _currentEditableLesson;
            set
            {
                _currentEditableLesson = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand _saveUpdatedLessonCommand;
        public RelayCommand SaveUpdatedLessonCommand => _saveUpdatedLessonCommand ??
                            (_saveUpdatedLessonCommand = new RelayCommand(SaveUpdatedLesson));

 
        private void SaveUpdatedLesson()
        {
            if (SelectedLesson==null || CurrentEditableLesson == null)
                return;

            //SelectedLesson.StudentID = CurrentEditableLesson.StudentID;
            //SelectedLesson.Time = CurrentEditableLesson.Time;
            //SelectedLesson.Date = CurrentEditableLesson.Date;
            //SelectedLesson.StudentID = CurrentEditableLesson.StudentID;
            //SelectedLesson.Notes = CurrentEditableLesson.Notes;
            //SelectedLesson.Duration = CurrentEditableLesson.Duration;
            //SelectedLesson.Attended = CurrentEditableLesson.Attended;
            //SelectedLesson.Paid = CurrentEditableLesson.Paid;

            SelectedLesson = CurrentEditableLesson;

            DataBase.UpdateLesson(SelectedLesson);

            if (IsDataToggled)
            {
                FutureLessonsList.Clear();
                LoadFutureLessons();
               // TableStatus = "Предстоящие занятия: ";
            }
            else
            {
                FutureLessonsList.Clear();
                LoadPastLessons();

                //TableStatus = "Прошедшие занятия: ";
            }
            
            SelectedStudent = new Student();
            CurrentEditableLesson = new Lesson();

        }


        private RelayCommand _deleteLessonCommand;
        public RelayCommand DeleteLessonCommand => _deleteLessonCommand ??
                            (_deleteLessonCommand = new RelayCommand(DeleteLesson));

        private void DeleteLesson()
        {
            if (SelectedLesson == null)
                return;

            try 
            {
                DataBase.RemoveLesson(SelectedLesson.Id);
                MessageBox.Show($"Удаление урока за '{SelectedLesson.Date}' прошло успешно. ");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Что-то пошло не так: {ex.Message}");
            }
            finally
            {
                SelectedLesson = null;

                FutureLessonsList.Clear();

                if (IsDataToggled)
                {
                    FutureLessonsList.Clear();
                    LoadFutureLessons();
                    // TableStatus = "Предстоящие занятия: ";
                }
                else
                {
                    FutureLessonsList.Clear();
                    LoadPastLessons();

                    //TableStatus = "Прошедшие занятия: ";
                }

            }
        }

    }
}
