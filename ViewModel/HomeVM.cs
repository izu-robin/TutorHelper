using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using TutorHelper.View;
using System.Diagnostics.CodeAnalysis;
using TutorHelper.Model;

// using TutorHelper.Model; //почему здесь не надо? Может потому что он пустой? 

namespace TutorHelper.ViewModel
{


    class HomeVM : Utilities.ViewModelBase 
    {

        //public ObservableCollection<ShortLessons> Lessons { get; set; } = new();
        public string DateToday { get; set; }


        private readonly PageModel _pageModel;

        public HomeVM()
        {
            DateToday = DateTime.Now.ToString("d") + ", " + RussianDayOfWeek(DateTime.Now.DayOfWeek.ToString());
            






            /*
            //а может надо подрубить дату из календаря???? Сейчас с системы читает просто 

            //поставить только дату пока не получается, только дату-время англ.формата
            //tt = new DateOnly();
            //tt = DateOnly.FromDateTime(DateTime.Now);

            //создаем пару дамми-заглушек
            //Lessons.Add(new ShortLessons { _time = "12:00", _student = "Саша Хиханькин", _note = "долг по д/з с прошлого занятия" });
            //Lessons.Add(new ShortLessons { _time = "15:00", _student = "Ваня Хаханькин" });
            */
        }


        public string RussianDayOfWeek(string EngDay)
        {
            if (EngDay == "Monday")
                return "Понедельник";

            if (EngDay == "Tuesday")
                return "Вторник";


            if (EngDay == "Wednesday")
                return "Среда";

            if (EngDay == "Thursday")
                return "Четверг";

            if (EngDay == "Friday")
                return "Пятница";

            if (EngDay == "Saturday")
                return "Суббота";

            if (EngDay == "Sunday")
                return "Воскресенье";

            return "Ошибка";
        }


    }




    public class ShortLessons //: ObservableObject и без него отображается, пусть будет в комменте пока
    {
        // [ObservableProperty] doesn't work for whatever reason
        public string? _time { get; set; }
        public string? _student { get; set; }
        public string? _note { get; set; }

    };




}


