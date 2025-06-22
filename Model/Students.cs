using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorHelper.Model
{
    class StudentsInfo
    {
        public int ID { get; set; }
        public bool Paid { get; set; }
        public bool Unpaid { get; set; }

        public bool Attended { get; set; }

        public StudentsInfo() { }

        public StudentsInfo(StudentsInfo s)
        {
            ID = s.ID;
            Paid = s.Paid;
            Attended = s.Attended;
        }

    }
}
