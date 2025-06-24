using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using TutorHelper.Model;
using TutorHelper.Model.Core;
using TutorHelper.Utilities;
using TutorHelper.DataAccess;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Documents;

namespace TutorHelper.ViewModel
{
    class ReportVM : Utilities.ViewModelBase
    {
        public ReportVM()
        {
            CurrentReport = new();

            Years = new() { 2024, 2025, 2026, 2027, 2028, 2029, 2030, 2031, 2032, 2033, 2034, 2035 };

            Months = new();
            Months.Add(new Month(01, "Январь"));
            Months.Add(new Month(02, "Февраль"));
            Months.Add(new Month(03, "Март"));
            Months.Add(new Month(04, "Апрель"));
            Months.Add(new Month(05, "Май"));
            Months.Add(new Month(06, "Июнь"));
            Months.Add(new Month(07, "Июль"));
            Months.Add(new Month(08, "Август"));
            Months.Add(new Month(09, "Сентябрь"));
            Months.Add(new Month(10, "Октябрь"));
            Months.Add(new Month(11, "Ноябрь"));
            Months.Add(new Month(12, "Декабрь"));

        }

        private Month _selectedMonth;
        public Month SelectedMonth
        {
            get => _selectedMonth;
            set
            {
                _selectedMonth = value;
                OnPropertyChanged();
                CurrentReport.M = value?.Id ?? 0;
            }
        }

        private int _chosenYear;
        public int SelectedYear
        {
            get => _chosenYear;
            set
            {
                _chosenYear = value;
                OnPropertyChanged();
            }
        }
        public List<int> Years { get; } = new();

        public Report _currentReport;
        public Report CurrentReport
        {
            get => _currentReport ?? (_currentReport = new Report());
            set
            {
                _currentReport = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection <Month> Months { get; } = new();
        public ObservableCollection<Lesson> LessonsList { get; } = new();

        private RelayCommand _getReportCommand;
        public RelayCommand GetReportCommand => _getReportCommand ?? (_getReportCommand = new RelayCommand(GetReport));

        private void GetReport()
        {
            if (SelectedMonth.Id.ToString() == null || SelectedYear.ToString() == null)
                return;
            string dateStart = "";
            string dateFinish = "";
            if (SelectedMonth.Id.ToString().Length==1)
            {
                string mid = "0" + SelectedMonth.Id.ToString();
                dateStart = SelectedYear.ToString() + "/" + mid + "/01";
                dateFinish = SelectedYear.ToString() + "/" + mid + "/31";

            }else
            {
                dateStart = SelectedYear.ToString() + "/" + SelectedMonth.Id.ToString() + "/01";
                dateFinish = SelectedYear.ToString() + "/" + SelectedMonth.Id.ToString() + "/31";
            }
            LessonsList.Clear();
            CurrentReport=DataBase.LoadReport(dateStart, dateFinish, LessonsList);
        }
    }










}

