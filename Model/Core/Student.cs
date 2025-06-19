using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorHelper.Model.Core
{
    public class Student
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

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





    }
}
