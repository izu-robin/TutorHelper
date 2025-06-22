using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TutorHelper.DataAccess;
using TutorHelper.Model;
using TutorHelper.Model.Core;
using TutorHelper.Utilities;


namespace TutorHelper.ViewModel
{
    class SettingsVM : Utilities.ViewModelBase
    {
        public SettingsVM()
        {
            GetPricings();
            GetStudents();
            DeleteWithLessons = new bool();
        }

        public ObservableCollection<Student> AllStudentsList { get; } = new();
        public bool DeleteWithLessons { get; set; } = false; 

        private void GetStudents()
        {
            foreach (var stud in DataBase.GetStudents())
            {
                AllStudentsList.Add(stud);
            }

            AllStudentsList.RemoveAt(0);
        }

        private Student _selectedStudent;
        public Student SelectedStudent
        {
            get => _selectedStudent;
            set
            {
                _selectedStudent = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand _deleteStudentCommand;
        public RelayCommand DeleteStudentCommand => _deleteStudentCommand ?? (_deleteStudentCommand = new RelayCommand(DeleteStudent));

        private void DeleteStudent()
        {
            try
            {
                if (DeleteWithLessons)
                {
                    DataBase.RemoveStudentWithLessons(SelectedStudent);
                    MessageBox.Show($"Удаление ученика {SelectedStudent.FullName} вместе с занятиями прошло успешно.");

                }
                else
                {
                    DataBase.RemoveStudentOnly(SelectedStudent);
                    MessageBox.Show($"Удаление ученика {SelectedStudent.FullName} прошло успешно.");

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Удаление прервано: {ex.Message}");
            }
            finally
            {
                AllStudentsList.Clear();
                GetStudents();
                SelectedStudent = new Student();
            }
        }





        public ObservableCollection<Rate> AllRatesList { get; } = new();

        private void GetPricings()   //загрузка всех тарифов в комбобокс 
        {
            foreach (var rate in DataBase.LoadPricings())
            {
                AllRatesList.Add(rate);
            }
        }

        private Rate _selectedRate;
        public Rate SelectedRate
        {
            get => _selectedRate;
            set
            {
                _selectedRate = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand _deleteRateCommand;
        public RelayCommand DeleteRateCommand => _deleteRateCommand ?? 
                            (_deleteRateCommand = new RelayCommand(DeleteRate));
 
        private void DeleteRate()
        {
            if (SelectedRate == null)
                return; //проверка на пустоту

            try
            {
                DataBase.RemoveRate(SelectedRate.Id);
                MessageBox.Show($"Удаление тарифа '{SelectedRate.Title}' прошло успешно. ");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Удаление прервано: {ex.Message}");
            }
            finally
            {
                SelectedRate = null;

                AllRatesList.Clear();
                GetPricings();
            }
        }

       



    }
}
