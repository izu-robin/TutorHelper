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

        public string Date { get; set; }

        public string Time { get; set; }

        public string? Notes { get; set; } = null;

        public int Duration { get; set; }


        //navigation properties

        public List<Lesson> LessonsList { get; set; } = new();
        
    }
}
