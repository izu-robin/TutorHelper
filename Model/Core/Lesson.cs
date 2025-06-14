using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorHelper.Model.Core
{
    public class Lesson
    {
        public int Id { get; set; } 

        public int GroupID { get; set; }

        public string Date { get; set; } = "01.01.2001";

        public string Time { get; set; } = "00:00";

        public string? Notes { get; set; } = "-";

        public int Duration { get; set; } = 0;


        //navigation properties

        public List<Lesson> LessonsList { get; set; } = new();
        
    }
}
