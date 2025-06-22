using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TutorHelper.DataAccess;
using TutorHelper.Model;
using TutorHelper.Model.Core;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Controls;
using System.Diagnostics.Contracts;
using TutorHelper.Utilities; //for  ObservableCollection

namespace TutorHelper.ViewModel
{
    class StudentsVM : Utilities.ViewModelBase
    {
        public StudentsVM() //конструктор 
        {
            LoadStudents();
            GetRates();
            LoadTextbooks();
            SelectedRating = new Rate(RatesList[0]);
            SelectedTextbook = new TBook(TextbooksList[0]);
            studentsInfo = new StudentsInfo();
            NewStudent = new Student();
        }
        public ObservableCollection<Student> StudentsList { get; } = new();
        public ObservableCollection<Rate> RatesList { get; } = new();
        public ObservableCollection<TBook> TextbooksList { get; } = new();
        public ObservableCollection<Lesson> StudentsLessonsList { get; } = new();

        private  Student _newStudent;
        public Student NewStudent
        {
            get => _newStudent;
            set
            {
                _newStudent = value;
                OnPropertyChanged();
            }
        }
        private StudentsInfo _studentsInfo;
        public StudentsInfo studentsInfo
        {
            get => _studentsInfo;
            set
            {
                _studentsInfo = value;
                OnPropertyChanged();
            }
        }


        private void LoadStudents()
        {
            foreach( var stud in DataBase.GetStudents())
            {
                StudentsList.Add(stud);
            }
            StudentsList.RemoveAt(0);
        }

        private void LoadTextbooks()
        {
            foreach (var tb in DataBase.LoadTextbooks())
            {
                TextbooksList.Add(tb);
            }
        }

        //private void LoadStudentsLessons()
        //{
        //    foreach (var les in DataBase.GetStudentsLessons())
        //    {
        //        StudentsLessonsList.Add(les);
        //    }
        //}

        private Student _selectedStudent;
        public Student SelectedStudent
        {
            get => _selectedStudent;
            set
            {
                _selectedStudent = value;
                OnPropertyChanged();
          

                if (_selectedStudent!= null)
                {
                    CurrentEditableStudent = new Student(_selectedStudent);                
                }
            }
        }

        private Student _currentEditableStudent;
        public Student CurrentEditableStudent
        {
            get => _currentEditableStudent;
            set
            {
                _currentEditableStudent = value;
                OnPropertyChanged();
                if (SelectedRating != null && CurrentEditableStudent!=null)
                {
                    RatesList.Clear();
                    GetRates();
                    TextbooksList.Clear();
                    LoadTextbooks();
                    SelectedRating = FindRate(CurrentEditableStudent.RateID);
                    SelectedTextbook = FindTextbook(CurrentEditableStudent.TextbookId);
                }
            }
        }

        private Rate FindRate(int id)
        {
            for(int i=0; i<RatesList.Count; i++)
            {
                if (RatesList[i].Id == id)
                    return RatesList[i];
            }
            return new Rate();
        }

        private RelayCommand _saveEditedStudentCommand;
        public RelayCommand SaveEditedStudent => (_saveEditedStudentCommand ?? 
           (_saveEditedStudentCommand = new RelayCommand(SaveEditedStudentLessonsVM)));

        private void SaveEditedStudentLessonsVM()
        {
            if (SelectedStudent == null || CurrentEditableStudent == null)
                return;

            SelectedStudent.Name = CurrentEditableStudent.Name;
            SelectedStudent.Surname = CurrentEditableStudent.Surname;
            SelectedStudent.TextbookId = CurrentEditableStudent.TextbookId;
            SelectedStudent.RateID = SelectedRating.Id;
            SelectedStudent.TextbookId = SelectedTextbook.Id;
             
            //SelectedStudent = CurrentEditableStudent;
            DataBase.UpdateStudent(SelectedStudent);
            StudentsList.Clear();
            LoadStudents();
        }

        protected void GetRates()
        {
            foreach(var rate in DataBase.LoadPricings())
            {
                RatesList.Add(rate);
            }
        }

        private Rate _selectedRating;
        public Rate SelectedRating
        {
            get => _selectedRating;
            set
            {
                _selectedRating = value;
                OnPropertyChanged();

            }
        }

        private TBook _selectedTextbook;
        public TBook SelectedTextbook
        {
            get => _selectedTextbook;
            set
            {
                _selectedTextbook = value;
                OnPropertyChanged();
            }
        }

        private TBook FindTextbook(int id)
        {
            for (int i = 0; i < TextbooksList.Count; i++)
            {
                if (TextbooksList[i].Id == id)
                    return TextbooksList[i];
            }
            return new TBook();
        }

        private RelayCommand _getSelectedLessonsCommand;
        public RelayCommand GetSelectedLessonsCommand => (_getSelectedLessonsCommand ??
           (_getSelectedLessonsCommand = new RelayCommand(GetSelectedLessons)));

        private void GetSelectedLessons()
        {

            if (SelectedStudent == null)
                return;

            StudentsLessonsList.Clear();

            studentsInfo.ID = SelectedStudent.Id;

            foreach (var les in DataBase.GetStudentsLessons(studentsInfo))
             { StudentsLessonsList.Add(les); }
             
        }


        private RelayCommand _saveNewStudentCommand;
        public RelayCommand SaveNewStudentCommand => _saveNewStudentCommand ??  
                            (_saveNewStudentCommand = new RelayCommand(SaveNewStudent));

        private void SaveNewStudent()
        {
            NewStudent.RateID = SelectedRating.Id;
            DataBase.AddNewStudent(NewStudent);
            StudentsList.Clear();
            LoadStudents();

            NewStudent.Name = "";
            NewStudent.Surname = "";
        }


    }

}
