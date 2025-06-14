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
using System.Xml.Linq;
using TutorHelper.DataAccess;
using TutorHelper.Model.Core;
// using TutorHelper.Model; //почему здесь не надо? Может потому что он пустой? 

namespace TutorHelper.ViewModel
{


    public class HomeVM : Utilities.ViewModelBase 
    {
        //список уроков в выбранную дату
        public ObservableCollection<Lesson> DatesLessonsList { get; } = new();
   
        public static string? DateToday { get; set; }




        public string? _forTester ="empty";
        public string? ForTester
        {
            get => _forTester;
            set => SetField(ref _forTester, value ?? throw new ArgumentNullException(nameof(value)));

        }

        //свойство сохраняющее выбранную в календаре дату
        private DateTime? _selectedDate = DateTime.Today;
        public DateTime? SelectedDate
        {
            get => _selectedDate;
            set
            {
                if(SetField( ref _selectedDate, value)) //если удачно сохранилась новая дата
                {
                    DatesLessonsList.Clear();
                    // здесь с этой датой что-то происходит
                    OnDateSelected();
                }
            }
        }

        // и что с этой датой делается
        private void OnDateSelected()
        {
            //вспомогательное для дебага
            ForTester = SelectedDate.ToString();
            
            foreach(var dLes in DataBase.LoadDatesLessons(ForTester))
            {
                DatesLessonsList.Add(dLes);
            }
            
            
            
            
            
            
            //LoadDatesLessons(ForTester);
        }





        private readonly PageModel _pageModel;

        public HomeVM()
        {
            DateToday = DateTime.Now.ToString("d") + ", " + RussianDayOfWeek(DateTime.Now.DayOfWeek.ToString());
            OnDateSelected();






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

        public void NewCalendarDateSelected(string selectedDate)
        {
            //обновляет заглавную дату и запускает обновление списка уроков в таблице


            DateToday = selectedDate;
            ForTester = selectedDate;

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


