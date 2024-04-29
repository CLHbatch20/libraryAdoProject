using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ado.Net.Core.Application.Interfaces.Repositories;
using Ado.Net.Core.Domain.Entities;
using MySql.Data.MySqlClient;

namespace Ado.Net.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        StartUp startUp = new StartUp();
        public StudentRepository()
        {

        }
        public Student Add(Student student)
        {
              using(var connection = new MySqlConnection())
            {
                startUp.CreateConnection().Open();
                var sql = $"Insert into Student (UserEmail, AdmissionNumber) values ('{student.UserEmail}','{student.AdmissionNumber}')";
                    using (var command = new MySqlCommand(sql,connection))
                {
                    var studentAdded = command.ExecuteNonQuery();
                    if (studentAdded > 0)
                    {
                        return student;
                    }
                    return null;
                }
            }
        }

        public Student Delete(string userEmail)
        {
            Student student = null;
            using(var connection = new MySqlConnection())
            {
                startUp.CreateConnection().Open();
                var sql = $"Delete * from Student where UserEmail = @userEmail";
                using(var command = new MySqlCommand(sql,connection))
                {
                    command.Parameters.AddWithValue("@userEmail",userEmail);
                    int rowAffected = command.ExecuteNonQuery();
                    if (rowAffected > 0)
                    {
                       Console.WriteLine("Student Deleted"); 
                    }
                    else
                    {
                        Console.WriteLine("Student not Found");
                    }
                }
            }
            return student;
        }

        public Student Get(string email)
        {
            Student student = new Student();
            using(var connection = new MySqlConnection())
            {
                startUp.CreateConnection().Open();
                var sql = $"Select Name from Student where Email = @email";
                using(var command = new MySqlCommand(sql,connection))
                {
                    command.Parameters.AddWithValue("@email", email);
                    using(var reader = command.ExecuteReader())
                    {
                        Console.WriteLine("Student Book detail: ");
                        if (reader.Read())
                        {
                            student = new Student
                            {
                                UserEmail = reader.GetString("UserEmail"),
                              
                            };
                        }
                    }
                }
            }
            return student;
        }

        public ICollection<Student> GetAll()
        {
            ICollection<Student> students = new List<Student>();
            using(var connection = new MySqlConnection())
            {
                startUp.CreateConnection().Open();
                var sql = $"Select * from Student";
                using(var command = new MySqlCommand(sql,connection))
                {
                    Student student = null;
                    using(var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                         student = new Student()
                            {
                                UserEmail = reader.GetString("UserEmail"),
                                AdmissionNumber = reader.GetString("AdmissionNumber"),

                            };
                        }
                    }
                }
            }
            return students;
        }
    }
}