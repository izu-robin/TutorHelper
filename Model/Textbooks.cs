using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TutorHelper.DataAccess;

namespace TutorHelper.Model
{
    public class TBook  
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Level { get; set; }

  
         
     
        public TBook() {} //по умолчанию

        public TBook(TBook t) //от копирования 
        {
            Id = t.Id;
            Title = t.Title;
            Level = t.Level;
             
        }








    }
}
