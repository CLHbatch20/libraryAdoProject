using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ado.Net.Core.Application.Interfaces.Repositories;
using Ado.Net.Core.Domain.Entities;
using MySql.Data.MySqlClient;

namespace Ado.Net.Infrastructure.Repositories
{
    public class BorrowRepository : IBorrowRepository
    {
        StartUp startUp = new StartUp();
        public BorrowRepository()
        {

        }
        public Borrow Add(Borrow borrow)
        {
            using(var connection = new MySqlConnection())
            {
                startUp.CreateConnection().Open();
                var sql = $"Insert into Borrow (StudentEmail, BookName, DateBorrowed, DateReturned) values ('{borrow.StudentEmail}', '{borrow.BookName}', '{borrow.DateBorrowed}','{borrow.DateReturned}')";
                    using (var command = new MySqlCommand(sql,connection))
                {
                    var bookAdded = command.ExecuteNonQuery();
                    if (bookAdded > 0)
                    {
                        return borrow;
                    }
                    return null;
                }
            }
        }

        // public Borrow Delete(string studentEmail)
        // {
           
        //     Borrow borrowed = null;
        //     using(var connection = new MySqlConnection())
        //     {
        //         startUp.CreateConnection().Open();
        //         var sql = $"Delete * from Borrow where StudentEmail = @studentEmail";
        //         using(var command = new MySqlCommand(sql,connection))
        //         {
        //             command.Parameters.AddWithValue("@studentEmail",studentEmail);
        //             int rowAffected = command.ExecuteNonQuery();
        //             if (rowAffected > 0)
        //             {
        //                Console.WriteLine("Book Deleted"); 
        //             }
        //             else
        //             {
        //                 Console.WriteLine("Book not Found");
        //             }
        //         }
        //     }
        //     return borrowed;
        // }

        public Borrow Get(string bookName)
        {
            Borrow borrow = new Borrow();
            using(var connection = new MySqlConnection())
            {
                startUp.CreateConnection().Open();
                var sql = $"Select StudentEmail, BookName, DateBorrowed, DateReturned from Borrow where UserEmail = @Email";
                using(var command = new MySqlCommand(sql,connection))
                {
                    command.Parameters.AddWithValue("@BookName", bookName);
                    using(var reader = command.ExecuteReader())
                    {
                        Console.WriteLine("Borrowed Book detail: ");
                        if (reader.Read())
                        {
                            borrow = new Borrow
                            {
                                StudentEmail = reader.GetString("StudentEmail"),
                                BookName = reader.GetString("BookName"),
                                DateBorrowed = reader.GetDateTime(0),
                                DateReturned = reader.GetDateTime(1),
                            };
                        }
                    }
                }
            }
            return borrow;
        }

        public ICollection<Borrow> GetAll()
        {
            ICollection<Borrow> borrow = new List<Borrow>();
            using(var connection = new MySqlConnection())
            {
                startUp.CreateConnection().Open();
                var sql = $"Select * from Borrow";
                using(var command = new MySqlCommand(sql,connection))
                {
                    Borrow borrow2 = null;
                    using(var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                         borrow2 = new Borrow()
                            {
                                StudentEmail = reader.GetString("StudentEmail"),
                                BookName = reader.GetString("BookName"),
                                DateBorrowed = reader.GetDateTime(0),
                                DateReturned = reader.GetDateTime(1)
                            };
                        }
                    }
                }
            }
            return borrow;
        }
    }
}