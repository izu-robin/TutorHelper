using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TutorHelper.DataAccess;
using TutorHelper.Model;
using TutorHelper.Model.Core;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Controls; //for  ObservableCollection

namespace TutorHelper.ViewModel
{
    class StudentsVM : Utilities.ViewModelBase
    {
        public StudentsVM() //конструктор 
        {
            //_pageModel = new PageModel();
            //CustomerID = 100528;
            LoadStudents();

        }
        public ObservableCollection<Student> StudentsList { get; } = new();

        private void LoadStudents()
        {
            foreach( var stud in DataBase.GetStudents())
            {
                StudentsList.Add(stud);
            }
        }








  











    }

}
