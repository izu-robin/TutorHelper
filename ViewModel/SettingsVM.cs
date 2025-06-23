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
using System.ComponentModel;


namespace TutorHelper.ViewModel
{
    class SettingsVM : Utilities.ViewModelBase
    {
        public SettingsVM()
        {
            GetPricings();
            GetStudents();
            GetLessons();
            GetTextbooks();
            DeleteWithLessons = new bool();
        }

        //--------------удаление ученика--------------------------
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
            if (SelectedStudent == null)
                return;

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

        //--------------------------удаление занятия-----------------------------

        public ObservableCollection<Lesson> AllLessonsList { get; } = new();

        private void GetLessons()
        {
            foreach (var les in DataBase.GetAllLessons())
            {
                AllLessonsList.Add(les);
            }
            AllLessonsList.RemoveAt(0);
        }

        private Lesson _selectedLesson;
        public Lesson SelectedLesson
        {
            get => _selectedLesson;
            set
            {
                _selectedLesson = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand _deleteLessonCommand;
        public RelayCommand DeleteLessonCommand => _deleteLessonCommand ?? (_deleteLessonCommand = new RelayCommand(DeleteLesson));
        private void DeleteLesson()
        {
            if (SelectedLesson == null)
                return;

            try
            {
                DataBase.RemoveLesson(SelectedLesson.Id);
                MessageBox.Show($"Удаление урока '{SelectedLesson.DateAndName}' прошло успешно. ");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Удаление прервано: {ex.Message}");
            }
            finally
            {
                SelectedLesson = new Lesson();
                AllLessonsList.Clear();
                GetLessons();
            }
        }

        //--------------------------удаление тарифа--------------------------------
        public ObservableCollection<Rate> AllRatesList { get; } = new();

        private void GetPricings()   //загрузка всех тарифов в комбобокс 
        {
            foreach (var rate in DataBase.LoadPricings())
            {
                AllRatesList.Add(rate);
            }
            AllRatesList.RemoveAt(0);
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
                SelectedRate = new Rate();

                AllRatesList.Clear();
                GetPricings();
            }
        }

        //--------------------------------- удаление УМК ------------------------------

        public ObservableCollection<TBook> AllTextbooksList { get; } = new();

        private void GetTextbooks()
        {
            foreach (var tb in DataBase.LoadTextbooks())
            {
                AllTextbooksList.Add(tb);
            }
            AllTextbooksList.RemoveAt(0); 
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

        private RelayCommand _deleteTextbookCommand;
        public RelayCommand DeleteTextbookCommand => _deleteTextbookCommand ??
                            (_deleteTextbookCommand = new RelayCommand(DeleteTextbook));

        private void DeleteTextbook()
        {
            if (SelectedTextbook == null)
                return;

            try
            {
                DataBase.RemoveTextbook(SelectedTextbook.Id);
                MessageBox.Show($"Удаление учебника '{SelectedTextbook.Title}' прошло успешно. ");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Удаление прервано: {ex.Message}");
            }
            finally
            {
                SelectedTextbook = new TBook();
                AllTextbooksList.Clear();
                GetTextbooks();
            }
        }




    }
}
