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
using TutorHelper.Utilities;

namespace TutorHelper.ViewModel
{
    class SettingsVM : Utilities.ViewModelBase
    {
        //private readonly PageModel _pageModel;
        
        public ObservableCollection<Rate> AllRatesList { get; } = new();

        private Rate _selectedRate;
        public Rate SelectedRate
        {
            get => _selectedRate;
            set
            {
                _selectedRate = value;
                OnPropertyChanged();

                //активирует кнопку удаления, но не запускает 
                //DeleteCommand.RaiseCanExecuteChanged();
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
                MessageBox.Show($"Delete failed: {ex.Message}");
            }
            finally
            {
                SelectedRate = null;

                AllRatesList.Clear();
                GetPricings();
            }
        }









        //загрузка всех тарифов в комбобокс 
        private void GetPricings() //заполняет список тарифов строками из дб
        {
            foreach (var rate in DataBase.LoadPricings())
            {
                AllRatesList.Add(rate);
            }
        }


        public SettingsVM()
        {
            GetPricings();
             
        }

    }
}
