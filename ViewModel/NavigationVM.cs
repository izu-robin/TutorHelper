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
        public ICommand GroupsCommand { get; set; }
        public ICommand LessonsCommand { get; set; }
        public ICommand PricingCommand { get; set; }
        public ICommand SettingsCommand { get; set; }
        public ICommand StudentsCommand { get; set; }
        public ICommand TextbooksCommand { get; set; }

        private void Home(object obj) => CurrentView = new HomeVM();
        private void Groups(object obj) => CurrentView = new GroupsVM();
        private void Lessons(object obj) => CurrentView = new LessonsVM();
        private void Pricing(object obj) => CurrentView = new PricingVM();
        private void Settings(object obj) => CurrentView = new SettingsVM();
        private void Students(object obj) => CurrentView = new StudentsVM();
        private void Textbooks(object obj) => CurrentView = new TextbooksVM();

        public NavigationVM()
        {
            HomeCommand = new RelayCommand(Home);
            GroupsCommand = new RelayCommand(Groups);
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
