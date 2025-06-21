using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TutorHelper.Model.Core;

namespace TutorHelper.Model
{
    class Report : INotifyPropertyChanged
    {
        public int Y { get; set; }
        public int M { get; set; }

        private int _totalLessons;

        public int TotalLessons 
        {
            get => _totalLessons;
            set
            {
                _totalLessons = value;
               OnPropertyChanged();
            }
        }

        public int _paidLessons;
        public int PaidLessons
        {
            get => _paidLessons;
            set
            {
                _paidLessons = value;
                OnPropertyChanged();
            }
        }

        public int _totalSum;
        public int TotalSum
        {
            get => _totalSum;
            set
            {
                _totalSum = value;
                OnPropertyChanged();
            }
        }


        public Report() { }

        public Report(Report r)
        {
            Y = r.Y;
            M = r.M;
            TotalLessons = r.TotalLessons;
            PaidLessons = r.PaidLessons;
            TotalSum = r.TotalSum;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

    public class Month
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Month(int id, string n)
        {
            Id = id;
            Name = n;
        }

    } 

  


    }
