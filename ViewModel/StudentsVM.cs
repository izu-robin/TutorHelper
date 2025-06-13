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
using System.Collections.ObjectModel; //for  ObservableCollection

namespace TutorHelper.ViewModel
{
    class StudentsVM : Utilities.ViewModelBase
    {

        public ObservableCollection<Student> StudentsList { get; } = new();

        private void LoadStudents()
        {
            foreach( var stud in DataBase.GetStudents())
            {
                StudentsList.Add(stud);
            }
        }



        public StudentsVM()
        {
            //_pageModel = new PageModel();
            //CustomerID = 100528;
            LoadStudents();

        }







        

       


    }

}
