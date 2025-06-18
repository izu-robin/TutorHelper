using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace TutorHelper.Model
{
    public class Rate
    {
       
        public int Id { get; set; }

        public string? Title { get; set; }

        public int Price { get; set; }

        public Rate() { }  //базовый, нужен для работы с SQLite в данном случае

        public Rate(Rate B) //от копирования
        {
            Id = B.Id;
            Title = B.Title;
            Price = B.Price;
        }











    };
    
}
