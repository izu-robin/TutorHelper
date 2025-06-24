using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TutorHelper.Model.Core
{
    public class Student : INotifyPropertyChanged
    {
        public int Id { get; set; }

        private string? _name;
        public string? Name 
        {
            get => _name; 
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private string? _surname;
        public string? Surname  
        {
            get => _surname;
            set
            {
                _surname = value;
                OnPropertyChanged();
            }
        }
        public string FullName
        {
            get => $"{Name} {Surname}";
        }
  
        public int TextbookId { get; set; }
        public string? TextbookTitle { get; set; }

        public int RateID { get; set; }

        public string RateTitle { get; set; }

        public Student() { }

        public Student(Student a)
        {
            Id = a.Id;
            Name = a.Name;
            Surname = a.Surname;
            TextbookId = a.TextbookId;
            TextbookTitle = a.TextbookTitle;
            RateID = a.RateID;
            RateTitle = a.RateTitle;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
