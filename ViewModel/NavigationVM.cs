using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using TutorHelper.Utilities;
using System.Windows.Input;
using System.Transactions;
using TutorHelper.View;

namespace TutorHelper.ViewModel
{
    class NavigationVM : Utilities.ViewModelBase
    {

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public ICommand HomeCommand { get; set; }
        public ICommand ReportCommand { get; set; }
        public ICommand LessonsCommand { get; set; }
        public ICommand PricingCommand { get; set; }
        public ICommand SettingsCommand { get; set; }
        public ICommand StudentsCommand { get; set; }
        public ICommand TextbooksCommand { get; set; }

        private void Home() => CurrentView = new HomeVM(); //(object obj)
        private void Report() => CurrentView = new ReportVM(); //object obj
        private void Lessons() => CurrentView = new LessonsVM(); //object obj
        private void Pricing() => CurrentView = new PricingVM(); //у остальных 4 так же
        private void Settings() => CurrentView = new SettingsVM();
        private void Students() => CurrentView = new StudentsVM();
        private void Textbooks() => CurrentView = new TextbooksVM();

        public NavigationVM()
        {
            HomeCommand = new RelayCommand(Home);
            ReportCommand = new RelayCommand(Report);
            LessonsCommand = new RelayCommand(Lessons);
            PricingCommand = new RelayCommand(Pricing);
            SettingsCommand = new RelayCommand(Settings);
            StudentsCommand = new RelayCommand(Students);
            TextbooksCommand = new RelayCommand(Textbooks);

            // Startup Page
            CurrentView = new HomeVM();

        }
    }
}
