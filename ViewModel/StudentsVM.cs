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
        }
        public ObservableCollection<Student> StudentsList { get; } = new();
        public ObservableCollection<Rate> RatesList { get; } = new();

        private void LoadStudents()
        {
            foreach( var stud in DataBase.GetStudents())
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
            }
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
            SelectedStudent.RateID = CurrentEditableStudent.RateID;

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

                CurrentEditableStudent.RateID = value?.Id ?? 0;
            }
        }













    }

}
