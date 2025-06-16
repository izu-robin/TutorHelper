using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using TutorHelper.View;
using TutorHelper.ViewModel;
using TutorHelper.Model.Core;
using static TutorHelper.ViewModel.StudentsVM;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace TutorHelper.DataAccess
{

    class DataBase
    {

        //public static string ConnectionString = "Data Source=L:\\Programming\\Codin\\C#\\TutorHelper\\DataAccess\\TutorHelperDB.db";
        public static string ConnectionString = "Data Source=DataAccess\\TutorHelperDB.db";
                                                //Solved - Debug directory set to project folder, what should I do in release though?

        //get all students - for (Students View)
        public static List<Student> GetStudents()
        {
                var students = new List<Student>();

                using var connection = new SqliteConnection(ConnectionString);
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Student";

                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    students.Add(new Student { Id = reader.GetInt32(0), 
                                               Name = reader.GetString(1), 
                                               Surname = reader.GetString(2) });
                }
                return students;
        }

        //get all future (not yet) lessons for (Lessons View)
        public static List<Lesson> GetFutureLessons()
        {
            var lessons = new List<Lesson>();
            //Lesson mid = new Lesson();

            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Lesson";

            using var reader = command.ExecuteReader();
            while(reader.Read())
            {
                Lesson mid = new Lesson();
                mid.Id = reader.GetInt32(0);
                mid.GroupID = reader.GetInt32(1);
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

                    lessons.Add(mid);
            }
            return lessons;
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
            command.CommandText = "SELECT * FROM Lesson WHERE Lesson.Date ='" + dashDate +"'"+ " ORDER BY Lesson.Time ASC";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Lesson mid = new Lesson();
                mid.Id = reader.GetInt32(0);
                mid.GroupID = reader.GetInt32(1);
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


















        /*
        //{
        //string _connectionString;


        //public DBDataAccess(string dbName)
        //{
        //    _connectionString = ConfigurationManager.ConnectionStrings[dbName].ConnectionString;
        //}

        //public void TestConnection()
        //{
        //    try
        //    {
        //        var con = new SqliteConnection(_connectionString);
        //        con.Open();
        //        con.Close();

        //        //Console.WriteLine("Connection buit!");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Connection failed.");
        //    }
        //}

        //public void AddStudent(Student student)
        //{
            //var sql = "INSERT INTO Student (Name, Surname) " +
            //          "VALUES (@name, @surname)";

            //try
            //{
            //    int result = 0;
            //    using (var con = new SqliteConnection(_connectionString))
            //    {
            //        con.Open();
            //        using (var cmd = new SqliteCommand(sql, con))
            //        {
            //            cmd.Parameters.AddWithValue("@name", student.Name);
            //            cmd.Parameters.AddWithValue("@surname", student.Surname);

            //            result = cmd.ExecuteNonQuery();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{

            //}
        //}


        //public List<Student>GetAllStudents()
        //{
        //    List<Student> result = new List<Student>();
        //    var sql = "SELECT * FROM Student";
        //    try
        //    {
        //        using (var con = new SqliteConnection(_connectionString))
        //        {
        //            con.Open();
        //            using (var cmd = new SqliteCommand(sql, con))
        //            {
        //                using (var rdr = cmd.ExecuteReader())
        //                {
        //                    if (rdr.HasRows)
        //                    {
        //                        while(rdr.Read())
        //                        {
        //                            var p = new Student();
        //                            p.Name = Convert.ToString(rdr["Name"]);
        //                            p.Surname = Convert.ToString(rdr["Surname"]);
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        Console.WriteLine("Failure");
        //    }
        //    return result;
        //}

    //};
    */



    }
}

    

    







        
