using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorHelper.DataAccess;
using TutorHelper.Model;
using TutorHelper.Utilities;

namespace TutorHelper.ViewModel
{
    class PricingVM : Utilities.ViewModelBase
    {
        public ObservableCollection<Rate> PricingsList { get; } = new();

        private void GetPricings() //заполняет список тарифов строками из дб
        {
            foreach(var rate in DataBase.LoadPricings())
            {
                PricingsList.Add(rate);
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

                if( _selectedRating != null)
                {
                    CurrentEditableRating = new Rate(_selectedRating);
                }
            }
        }

        private Rate _currentEditableRating;
        public Rate CurrentEditableRating
        {
            get => _currentEditableRating;
            set 
            { 
                _currentEditableRating = value; 
                OnPropertyChanged();
            }
        }


        private RelayCommand _saveCommand;
        public RelayCommand SaveCommand => _saveCommand ?? (_saveCommand = new RelayCommand(SaveRatingChanges));
        private void SaveRatingChanges()
        {
            if (SelectedRating == null || CurrentEditableRating == null)
                return; //ранний выход если сохранять нечего и это мисклик

            //внесли изменения в выделенный элемент
            SelectedRating.Title = CurrentEditableRating.Title;
            SelectedRating.Price = CurrentEditableRating.Price;

            DataBase.UpdateRate(SelectedRating);

            var index = PricingsList.IndexOf(SelectedRating);
            PricingsList[index] = SelectedRating;

            PricingsList.Clear();

            GetPricings();

        }

        public Rate NewRate { get; set; } = new Rate();

        private RelayCommand _saveNewRateCommand;
        public RelayCommand SaveNewRateCommand => _saveNewRateCommand ?? 
                            (_saveNewRateCommand = new RelayCommand(SaveNewRating));

        private void SaveNewRating()
        {
            if( string.IsNullOrWhiteSpace(NewRate.Title) || string.IsNullOrWhiteSpace((NewRate.Price).ToString()))
            {
                return; //ранний ритёрн на случай незаполненных полей 
            }

            int newId = DataBase.AddRate(NewRate);

            PricingsList.Clear();

            GetPricings();

            NewRate = new Rate();
            OnPropertyChanged();






        }


















        public PricingVM()
        {
            GetPricings();

        }











        //private readonly PageModel _pageModel;

    }
}
