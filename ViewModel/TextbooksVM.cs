using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using TutorHelper.DataAccess;
using TutorHelper.Model;
using TutorHelper.Utilities;


namespace TutorHelper.ViewModel
{
    class TextbooksVM : Utilities.ViewModelBase
    {
        //private readonly PageModel _pageModel;

        public TextbooksVM()
        {
            GetTextbooks();
            CreateNewTextbookCommand = new RelayCommand(CreateNewTextbook);

            
        }

        public ObservableCollection<TBook> TextbooksList { get; } = new();

        private void GetTextbooks()
        {
            foreach ( var tbook in DataBase.LoadTextbooks())
            {
                TextbooksList.Add(tbook);
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

                if (_selectedTextbook != null)
                {
                    CurrentEditableTextbook = new TBook(_selectedTextbook);
                }
            }
        }

        private TBook _currentEditableTextbook;
        public TBook CurrentEditableTextbook
        {
            get => _currentEditableTextbook;
            set
            {
                _currentEditableTextbook = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand _saveEditedTextbookCommand;
        public RelayCommand SaveEditedTextbookCommand => (_saveEditedTextbookCommand ?? (_saveEditedTextbookCommand = new RelayCommand(SaveEditedTextbook)));

        private void SaveEditedTextbook()
        {
            if (SelectedTextbook == null || CurrentEditableTextbook == null)
                return;

            SelectedTextbook.Title = CurrentEditableTextbook.Title;
            SelectedTextbook.Level = CurrentEditableTextbook.Level;

            DataBase.UpdateTextbook(SelectedTextbook);

            TextbooksList.Clear();
            GetTextbooks();
        }

        //объект для нового учебника
        public TBook NewTextbook { get; set; } = new TBook();

        public RelayCommand CreateNewTextbookCommand { get; }

        private void CreateNewTextbook()
        {
            if (string.IsNullOrWhiteSpace(NewTextbook.Title) || string.IsNullOrWhiteSpace(NewTextbook.Level))
                return; //выкатываемся если не заполнено одно из полей

            int newID = DataBase.AddTextbook(NewTextbook);

            //NewTextbook.Id = newID;
            //TextbooksList.Add(NewTextbook);

            //очищаем и заново заполняем список, подгружаем из бд
            TextbooksList.Clear();
            GetTextbooks();

            NewTextbook = new TBook();
            OnPropertyChanged(nameof(NewTextbook));
        }












    }
}
