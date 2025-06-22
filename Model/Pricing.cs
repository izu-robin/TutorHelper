using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
 

namespace TutorHelper.Model
{
    public class Rate : INotifyPropertyChanged
    {

        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        private string? _title;
        public string? Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }



        public int Price { get; set; }

        public Rate() { }  //базовый, нужен для работы с SQLite в данном случае

        public Rate(Rate B) //от копирования
        {
            Id = B.Id;
            Title = B.Title;
            Price = B.Price;
        }







        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    };
    
}
