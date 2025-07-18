﻿using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using TutorHelper.View;
using TutorHelper.ViewModel;
using TutorHelper.Model;
using TutorHelper.Model.Core;
using static TutorHelper.ViewModel.StudentsVM;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Web;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Controls.Primitives;
using System.Security.Cryptography;
using System.Reflection.PortableExecutable;
using System.Collections.ObjectModel;


namespace TutorHelper.DataAccess
{

    class DataBase
    {

        //public static string ConnectionString = "Data Source=L:\\Programming\\Codin\\C#\\TutorHelper\\DataAccess\\TutorHelperDB.db";
        public static string ConnectionString = "Data Source=DataAccess\\TutorHelperDB.db";
        //Solved - Debug directory set to project folder 

        //----------------- Home -----------------------------------------------
        public static void AddLesson(Lesson l)
        {
            using var con = new SqliteConnection(ConnectionString);
            {
                con.Open();
                string sql = "INSERT INTO Lesson (StudentID, LessonDate, StartTime, Duration) VALUES (@StudentID, @Date, @Time, @Duration); "
                            ;

                using (var cmd = new SqliteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@StudentID", l.StudentID);
                    cmd.Parameters.AddWithValue("@Date", l.Date);
                    cmd.Parameters.AddWithValue("@Time", l.Time);
                    cmd.Parameters.AddWithValue("@Duration", l.Duration);

                    //return Convert.ToInt32(
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //загрузка занятий в конкретную дату
        public static List<Lesson> LoadDatesLessons(string date)
        {
            string[] arr = date.Split(' ');
            string shortRevDate = arr[0];

            string dashDate = DateCorrector(shortRevDate);

            var lessons = new List<Lesson>();

            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT Lesson.*, Student.Name, Student.Surname " +
                                    "FROM Lesson join Student ON Lesson.StudentID=Student.StudentID " +
                                    "WHERE Lesson.LessonDate = '" + dashDate + "'" + " ORDER BY Lesson.StartTime ASC";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Lesson mid = new Lesson();
                mid.Id = reader.GetInt32(0);
                mid.StudentID = reader.GetInt32(1);
                mid.Date = reader.GetString(2);
                mid.Time = reader.GetString(3);

                if (!reader.IsDBNull(4))
                    mid.Notes = reader.GetString(4);
                else
                    mid.Notes = "-";
                if (!reader.IsDBNull(5))
                    mid.Duration = reader.GetInt32(5);
                else
                    mid.Duration = 60;

                //булевские поля
                if (reader.GetInt32(6) == 1)
                    mid.Attended = true;
                else
                    mid.Attended = false;

                if (reader.GetInt32(7) == 1)
                    mid.Paid = true;
                else
                    mid.Paid = false;

                //имя-фамилия
                if (!reader.IsDBNull(8))
                    mid.Name = reader.GetString(8);
                else
                    mid.Notes = "-";

                if (!reader.IsDBNull(9))
                    mid.Surname = reader.GetString(9);
                else
                    mid.Surname = "-";

                lessons.Add(mid);
            }
            return lessons;

        }

        public static string DateCorrector(string date)
        {
            // 06.05.2025 -> 2025/05/06

            string[] arr = date.Split('.');
            string answ = arr[2] + "/" + arr[1] + "/" + arr[0];
            return answ;
        }

        //get all students - for (Students View)--------------------------------
        public static List<Student> GetStudents()
        {
            var students = new List<Student>();

            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT Student.StudentID, Student.Name, Student.Surname, Student.TextbookID, Textbook.Title, Student.PricingID, Pricing.Title FROM Student left join Textbook ON Student.TextbookID=Textbook.TextbookID join Pricing on Student.PricingID = Pricing.PricingID";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Student stud = new Student();

                stud.Id = reader.GetInt32(0);
                stud.Name = reader.GetString(1);
                stud.Surname = reader.GetString(2);

                if (!reader.IsDBNull(3))
                    stud.TextbookId = reader.GetInt32(3);
                else
                    stud.TextbookId = 0;

                if (!reader.IsDBNull(4))
                    stud.TextbookTitle = reader.GetString(4);
                else
                    stud.TextbookTitle = " - ";

                if (!reader.IsDBNull(5))
                    stud.RateID = reader.GetInt32(5);
                else
                    stud.RateID = 0;

                if (!reader.IsDBNull(6))
                    stud.RateTitle = reader.GetString(6);
                else
                    stud.RateTitle = " - ";


                students.Add(stud);
            }
            return students;
        }

        //get all future lessons for (Lessons View)
        public static List<Lesson> GetFutureLessons(string date)
        {
            var lessons = new List<Lesson>();
            //Lesson mid = new Lesson();

            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT Lesson.*, Student.Name, Student.Surname FROM Lesson join Student on Lesson.StudentID=Student.StudentID WHERE Lesson.LessonDate >= '" + DateCorrector(date) + "' ORDER BY Lesson.LessonDate, Lesson.StartTime";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Lesson mid = new Lesson();
                mid.Id = reader.GetInt32(0);
                mid.StudentID = reader.GetInt32(1);
                mid.Date = reader.GetString(2);
                mid.Time = reader.GetString(3);

                if (!reader.IsDBNull(4))
                    mid.Notes = reader.GetString(4);
                else
                    mid.Notes = "-";
                if (!reader.IsDBNull(5))
                    mid.Duration = reader.GetInt32(5);
                else
                    mid.Duration = 60;

                //булевские поля
                if (reader.GetInt32(6) == 1)
                    mid.Attended = true;
                else
                    mid.Attended = false;

                if (reader.GetInt32(7) == 1)
                    mid.Paid = true;
                else
                    mid.Paid = false;

                //имя-фамилия
                if (!reader.IsDBNull(8))
                    mid.Name = reader.GetString(8);
                else
                    mid.Notes = "-";

                if (!reader.IsDBNull(9))
                    mid.Surname = reader.GetString(9);
                else
                    mid.Surname = "-";

                lessons.Add(mid);
            }
            return lessons;
        }

        public static List<Lesson> GetPastLessons(string date)
        {
            var lessons = new List<Lesson>();
            //Lesson mid = new Lesson();

            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT Lesson.*, Student.Name, Student.Surname FROM Lesson join Student on Lesson.StudentID=Student.StudentID WHERE Lesson.LessonDate < '" + DateCorrector(date) + "' ORDER BY Lesson.LessonDate, Lesson.StartTime";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Lesson mid = new Lesson();
                mid.Id = reader.GetInt32(0);
                mid.StudentID = reader.GetInt32(1);
                mid.Date = reader.GetString(2);
                mid.Time = reader.GetString(3);

                if (!reader.IsDBNull(4))
                    mid.Notes = reader.GetString(4);
                else
                    mid.Notes = "-";
                if (!reader.IsDBNull(5))
                    mid.Duration = reader.GetInt32(5);
                else
                    mid.Duration = 60;

                //булевские поля
                if (reader.GetInt32(6) == 1)
                    mid.Attended = true;
                else
                    mid.Attended = false;

                if (reader.GetInt32(7) == 1)
                    mid.Paid = true;
                else
                    mid.Paid = false;

                //имя-фамилия
                if (!reader.IsDBNull(8))
                    mid.Name = reader.GetString(8);
                else
                    mid.Notes = "-";

                if (!reader.IsDBNull(9))
                    mid.Surname = reader.GetString(9);
                else
                    mid.Surname = "-";

                lessons.Add(mid);
            }
            return lessons;
        }

        

        //загрузка списка учебников для PricingVM
        public static List<Rate> LoadPricings()
        {
            var pricings = new List<Rate>();

            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Pricing";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                pricings.Add(new Rate
                {
                    Id = reader.GetInt32(0),
                    Title = reader.GetString(1),
                    Price = reader.GetInt32(2)
                });
            }
            return pricings;

        }

        public static List<TBook> LoadTextbooks()
        {
            var textbooks = new List<TBook>();

            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "Select Textbook.TextbookID, Textbook.Title, Textbook.Level  FROM Textbook ORDER BY Textbook.TextbookID";
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                TBook mid = new TBook();

                mid.Id = reader.GetInt32(0);
                mid.Title = reader.GetString(1);
                mid.Level = reader.GetString(2);

                textbooks.Add(mid);
            }

            return textbooks;
        }


        public static void UpdateRate(Rate r)
        {
            using var con = new SqliteConnection(ConnectionString);
            {
                con.Open();
                string sql = "UPDATE Pricing SET Title = @Title, HourRate = @Price WHERE PricingID = @Id";

                using (var cmd = new SqliteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Title", r.Title);
                    cmd.Parameters.AddWithValue("@Price", r.Price);
                    cmd.Parameters.AddWithValue("@Id", r.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateTextbook(TBook t)
        {
            using var con = new SqliteConnection(ConnectionString);
            {
                con.Open();
                string sql = "UPDATE Textbook SET Title = @Title, Level = @Level WHERE TextbookID = @Id";

                using (var cmd = new SqliteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Title", t.Title);
                    cmd.Parameters.AddWithValue("@Level", t.Level);
                    cmd.Parameters.AddWithValue("@Id", t.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static int AddTextbook(TBook newTBook)
        {
            using var con = new SqliteConnection(ConnectionString);
            {
                con.Open();
                string sql = "INSERT INTO Textbook (Title, Level) VALUES (@Title, @Level); "
                           + "SELECT last_insert_rowid();";

                using (var cmd = new SqliteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Title", newTBook.Title);
                    cmd.Parameters.AddWithValue("@Level", newTBook.Level);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
        public static int AddRate(Rate r)
        {
            using var con = new SqliteConnection(ConnectionString);
            {
                con.Open();
                string sql = "INSERT INTO Pricing (Title, HourRate) VALUES (@Title, @HourRate); "
                           + "SELECT last_insert_rowid();";

                using (var cmd = new SqliteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Title", r.Title);
                    cmd.Parameters.AddWithValue("@HourRate", r.Price);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }


        }

        // ----------------- Settings--------------------------------
        public static void RemoveStudentOnly(Student s)
        {
            using var con = new SqliteConnection(ConnectionString);
            {
                con.Open();

                string sql = "UPDATE Lesson SET StudentID = 0 WHERE StudentID = @StudentID";
                using (var cmd= new SqliteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@StudentID", s.Id);
                    cmd.ExecuteNonQuery();
                }

                sql = "DELETE FROM Student WHERE StudentID = @Id";
                using (var cmd = new SqliteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Id", s.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void RemoveStudentWithLessons(Student s)
        {

            using var con = new SqliteConnection(ConnectionString);
            {
                con.Open();

                string sql = "DELETE FROM Lesson WHERE StudentID = @Id";
                using (var cmd= new SqliteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Id", s.Id);
                    cmd.ExecuteNonQuery();
                }

                sql = "DELETE FROM Student WHERE StudentID = @Id";
                using (var cmd = new SqliteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Id", s.Id);
                    cmd.ExecuteNonQuery();
                }

            }
        }

        public static List<Lesson> GetAllLessons()
        {

            List<Lesson> list = new List<Lesson>();

            using var connection = new SqliteConnection(ConnectionString);
            { connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "SELECT Lesson.LessonDate, Student.Name, Student.Surname, Lesson.LessonID FROM Lesson join Student on Student.StudentID=Lesson.StudentID ORDER BY Lesson.LessonDate ASC, Lesson.StartTime ASC";

                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Lesson mid = new Lesson();
                    mid.Date = reader.GetString(0);
                    mid.Name = reader.GetString(1);
                    mid.Surname = reader.GetString(2);
                    mid.Id = reader.GetInt32(3);

                    list.Add(mid);
                }
            }

            return list;

        }

        public static void RemoveRate(int Id)
        {
            using var con = new SqliteConnection(ConnectionString);
            {
                con.Open();

                string sql = "DELETE FROM Pricing WHERE PricingID = @Id";
                using (var cmd = new SqliteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void RemoveTextbook(int id)
        {
            using var con = new SqliteConnection(ConnectionString);
            {
                con.Open();

                string sql = $"DELETE FROM Textbook WHERE TextbookID = @TextbookID";
                using (var cmd = new SqliteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@TextbookID", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void AddNewStudent(Student s)
        {
            using var con = new SqliteConnection(ConnectionString);
            {
                con.Open();
                string sql = $"INSERT INTO Student (Name, Surname, PricingID, TextbookID) VALUES (@Name, @Surname, @PricingID, @TextbookID)";
                using (var cmd= new SqliteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Name", s.Name);
                    cmd.Parameters.AddWithValue("@Surname", s.Surname);
                    cmd.Parameters.AddWithValue("@PricingID", s.RateID);
                    cmd.Parameters.AddWithValue("@TextbookID", 0);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        //-----------------Students---------------------------------------------

        public static void UpdateStudent(Student s)
        {
            using var con = new SqliteConnection(ConnectionString);
            {
                con.Open();
                string sql = "UPDATE Student SET Name = @Name, Surname = @Surname, TextbookID = @TextbookID, PricingID = @PricingID  WHERE StudentID = @Id";
                using (var cmd = new SqliteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Name", s.Name);
                    cmd.Parameters.AddWithValue("@Surname", s.Surname);
                    cmd.Parameters.AddWithValue("@TextbookID", s.TextbookId);
                    cmd.Parameters.AddWithValue("@PricingID", s.RateID);
                    cmd.Parameters.AddWithValue("@Id", s.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }



        public static List<Lesson> GetStudentsLessons(StudentsInfo s)
        {
            List<Lesson> list = new List<Lesson>();
            //базовый запрос, общая часть для всех
            string sql = $"SELECT Lesson.StudentID, Lesson.LessonDate, Lesson.StartTime, Lesson.Attended, Lesson.Paid  FROM Lesson Where Lesson.StudentID={s.ID}";

            if( (s.Paid && s.Unpaid && s.Attended) || (!s.Paid && !s.Unpaid && s.Attended) )
             {
                //все оплаченные и неоплаченные посещенные
                sql += "  AND Lesson.Attended=1 ORDER BY Lesson.LessonDate";
             }
            else if ((s.Paid && s.Unpaid && !s.Attended) || (!s.Paid && !s.Unpaid && !s.Attended))
            {
                //оплаченные+неоплаченные не важно посещенные или нет
                //так и остается
                sql += " ORDER BY Lesson.LessonDate";
            }
            else if (s.Paid && !s.Unpaid && !s.Attended)
            {
                //оплаченные 
                sql += " AND Lesson.Paid=1 ORDER BY Lesson.LessonDate";
            }
            else if (!s.Paid && s.Unpaid && !s.Attended)
            {
                //все неоплаченные
                sql += " AND Lesson.Paid=0 ORDER BY Lesson.LessonDate";
            }
            else if (s.Paid && !s.Unpaid && s.Attended)
            {
                //оплачено и посещено
                sql += " AND Lesson.Paid=1 AND Lesson.Attended=1 ORDER BY Lesson.LessonDate";
            }
            else if (!s.Paid && s.Unpaid && s.Attended)
            {
                //неоплачены посещены
                sql += " AND Lesson.Paid=0 AND Lesson.Attended=1 ORDER BY Lesson.LessonDate";
            }

            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = sql;

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Lesson mid = new Lesson();
                mid.StudentID = reader.GetInt32(0);
                mid.Date = reader.GetString(1);
                mid.Time = reader.GetString(2);

                //булевские поля
                if (reader.GetInt32(3) == 1)
                    mid.Attended = true;
                else
                    mid.Attended = false;

                if (reader.GetInt32(4) == 1)
                    mid.Paid = true;
                else
                    mid.Paid = false;

                list.Add(mid);
            }

            return list;

        }

        // --------------------------------- Lessons----------------------------
        public static void UpdateLesson(Lesson l)
        {
            using var con = new SqliteConnection(ConnectionString);
            {
                con.Open();
                string sql = "UPDATE Lesson SET StartTime = @StartTime, Notes = @Notes, LessonDate = @LessonDate, StudentID = @StudentID, Duration = @Duration, Attended = @Attended, Paid = @Paid  WHERE LessonID = @LessonID";

                using (var cmd = new SqliteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@StartTime", l.Time);
                    cmd.Parameters.AddWithValue("@LessonDate", l.Date);
                    cmd.Parameters.AddWithValue("@Notes", l.Notes);

                    cmd.Parameters.AddWithValue("@StudentID", l.StudentID);
                    cmd.Parameters.AddWithValue("@Duration", l.Duration);
                    //cmd.Parameters.AddWithValue("@StudentID", l.StudentID);
                    cmd.Parameters.AddWithValue("@LessonID", l.Id);

                    if (l.Attended)
                        cmd.Parameters.AddWithValue("@Attended", 1);
                    else
                        cmd.Parameters.AddWithValue("@Attended", 0);

                    if (l.Paid)
                        cmd.Parameters.AddWithValue("@Paid", 1);
                    else
                        cmd.Parameters.AddWithValue("@Paid", 0);



                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void RemoveLesson(int Id)
        {
            using var con = new SqliteConnection(ConnectionString);
            {
                con.Open();

                string sql = "DELETE FROM Lesson WHERE LessonID = @Id";
                using (var cmd = new SqliteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //----------------------------Reports--------------------------------------

        public static Report LoadReport(string start, string finish, ObservableCollection<Lesson> list)
        {
            Report rep = new Report();

            using var con = new SqliteConnection(ConnectionString);
            {
                con.Open();

                var command = con.CreateCommand();
                command.CommandText = $"SELECT Lesson.LessonDate, Lesson.StartTime, Student.Name, Student.Surname, Lesson.Duration, Lesson.Paid From Lesson join Student on Lesson.StudentID = Student.StudentID WHERE Lesson.LessonDate >= '{start}' AND Lesson.LessonDate < '{finish}' AND Lesson.Attended=1";

                using var reader = command.ExecuteReader();
                {
                    while (reader.Read())
                    {
                        Lesson mid = new Lesson();
                        mid.Date = reader.GetString(0);
                        mid.Time = reader.GetString(1);
                        mid.Name = reader.GetString(2);
                        mid.Surname = reader.GetString(3);
                        mid.Duration = reader.GetInt32(4);

                        if (reader.GetInt32(5) == 1)
                            mid.Paid = true;
                        else
                            mid.Paid = false;

                        list.Add(mid);
            
                    }
                    
                }reader.Close();

                var command1 = con.CreateCommand();
                command1.CommandText = $"Select Count(Lesson.LessonID) From Lesson Where Lesson.LessonDate>='" + start + "' AND Lesson.LessonDate<'" + finish +"' AND Lesson.Attended=1";
                using var reader1 = command1.ExecuteReader();
                while (reader1.Read())
                {
                    if (!reader1.IsDBNull(0))
                        rep.TotalLessons = reader1.GetInt32(0);
                    else
                        rep.TotalLessons = 0;
                }

                var command2 = con.CreateCommand();
                command2.CommandText = $"Select Count(Lesson.LessonID) From Lesson  WHERE Lesson.LessonDate >= '{start}' AND Lesson.LessonDate < '{finish}' AND Lesson.Paid=1 AND Lesson.Attended=1";                
                using var reader2 = command2.ExecuteReader();
                while (reader2.Read())
                {
                    if (!reader2.IsDBNull(0))
                        rep.PaidLessons = reader2.GetInt32(0);
                    else
                        rep.PaidLessons = 0;
                }

                var command3 = con.CreateCommand();
                command3.CommandText = $"Select sum(Pricing.HourRate) From Lesson join Student on Lesson.StudentID=Student.StudentID join Pricing on Student.PricingID=Pricing.PricingID WHERE Lesson.LessonDate >= '{start}' AND Lesson.LessonDate < '{finish}' AND Lesson.Paid=1";
                using var reader3 = command3.ExecuteReader();
                while (reader3.Read())
                {
                    if (!reader3.IsDBNull(0))
                        rep.TotalSum = reader3.GetInt32(0);
                    else
                        rep.TotalSum = 0;
                }
                return rep;
            }
        }
    }
}

    

    







        
