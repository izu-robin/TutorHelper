using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace TutorHelper.Model.Core
{
    public class Lesson : INotifyPropertyChanged 
    {
        public int Id { get; set; } 

        public int StudentID { get; set; }

        public string? Name { get; set; } = "-";
        public string? Surname { get; set; } = "-";

        public string StudentFullName 
            {
                get => $"{Name} {Surname}";
            }


        private string _date;
        public string Date 
        {
            get => _date; 
            set
            {
                if (_date != value)
                {
                    _date = value;
                    OnPropertyChanged(nameof(Date));
                }
            }
        } 

        public string Time { get; set; } = " ";

        public string? Notes { get; set; } = " ";

        public int Duration { get; set; }

        public bool Attended { get; set; } = false;
        public bool Paid { get; set; } = false;

        private char _signPaid;
        public char SignPaid
        {
            get
            {
                if (Paid)
                    return '+';
                else
                    return '-';
            }
        }


        public Lesson() { } //по умолчанию
        public Lesson(Lesson a) //от копирования
        {
            Id = a.Id;
            StudentID = a.StudentID;
            Name = a.Name;
            Surname = a.Surname;
            Date = a.Date;
            Time = a.Time;
            Notes = a.Notes;
            Duration = a.Duration;
            Attended = a.Attended;
            Paid = a.Paid;
        }

        //navigation properties

        //public List<Lesson> LessonsList { get; set; } = new();


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
